import os
import shutil
import hashlib
import time

# Configuration
SOURCE_FOLDER_NAME = "temporal_raw_data"
PROJECT_ROOT = os.path.dirname(os.path.abspath(__file__))

# Destination Mappings
DESTINATIONS = {
    # Images
    ".jpg": "images",
    ".jpeg": "images",
    ".png": "images",
    ".gif": "images",
    ".bmp": "images",
    ".tga": "images",
    ".webp": "images",
    # Audio
    ".wav": "audio",
    ".mp3": "audio",
    ".ogg": "audio",
    ".flac": "audio",
    # Video
    ".mp4": "video",
    ".avi": "video",
    ".mov": "video",
    ".mkv": "video",
    # Documents
    ".pdf": "pdf",
    ".doc": "documents",
    ".docx": "documents",
    ".txt": "documents",
    ".md": "documents",
    ".json": "documents",
    # Code
    ".gd": "scripts",
    ".cs": "usercode",
    ".py": "mcp-servers",
    ".js": "classes",
    ".ts": "classes",
}

# Subfolders to create if missing
REQUIRED_DIRS = [
    "images",
    "audio",
    "video",
    "pdf",
    "documents",
    "scripts",
    "usercode",
    "mcp-servers",
    "classes",
]


def calculate_hash(file_path):
    """Calculate SHA256 hash of a file."""
    sha256_hash = hashlib.sha256()
    try:
        with open(file_path, "rb") as f:
            for byte_block in iter(lambda: f.read(4096), b""):
                sha256_hash.update(byte_block)
        return sha256_hash.hexdigest()
    except Exception as e:
        print(f"Error hashing {file_path}: {e}")
        return None


def scan_existing_files(root_dir):
    """Build a map of hash -> file_path for all files in the project to detect duplicates."""
    print("Scanning existing project files for duplicates...")
    existing_hashes = {}
    for root, dirs, files in os.walk(root_dir):
        # Skip special folders to save time/noise
        if ".git" in dirs:
            dirs.remove(".git")
        if "bin" in dirs:
            dirs.remove("bin")
        if "obj" in dirs:
            dirs.remove("obj")

        for file in files:
            path = os.path.join(root, file)
            file_hash = calculate_hash(path)
            if file_hash:
                existing_hashes[file_hash] = path
    return existing_hashes


def process_raw_data(source_dir):
    if not os.path.exists(source_dir):
        print(f"Source directory '{source_dir}' does not exist.")
        # Check if user meant the Mother-Brain location
        mb_path = r"c:\runnerapps\COSMIC-KEY\temporal_raw_data"
        if os.path.exists(mb_path):
            print(f"found temporal_raw_data in MOTHER-BRAIN ({mb_path}). Using that.")
            source_dir = mb_path
        else:
            print("Creating new local 'temporal_raw_data' folder.")
            os.makedirs(source_dir, exist_ok=True)
            print("Please dump your files there and run this script again.")
            return

    # Ensure destinations exist
    for d in REQUIRED_DIRS:
        os.makedirs(os.path.join(PROJECT_ROOT, d), exist_ok=True)

    existing_hashes = scan_existing_files(PROJECT_ROOT)

    print(f"\nProcessing files in '{source_dir}'...")
    processed_count = 0
    moved_count = 0
    dupe_count = 0

    for root, dirs, files in os.walk(source_dir):
        for file in files:
            processed_count += 1
            src_path = os.path.join(root, file)

            # Check Hash
            file_hash = calculate_hash(src_path)
            if not file_hash:
                continue

            if file_hash in existing_hashes:
                print(f"[DUPLICATE] {file} exists at {existing_hashes[file_hash]}")
                # Optional: Delete duplicate in source?
                # os.remove(src_path)
                dupe_count += 1
                continue

            # Organize
            ext = os.path.splitext(file)[1].lower()
            dest_folder = DESTINATIONS.get(ext, "extras")  # Default to 'extras'

            dest_path = os.path.join(PROJECT_ROOT, dest_folder, file)

            # Handle filename collision (same name, different content)
            if os.path.exists(dest_path):
                name, extension = os.path.splitext(file)
                timestamp = int(time.time())
                dest_path = os.path.join(
                    PROJECT_ROOT, dest_folder, f"{name}_{timestamp}{extension}"
                )

            # Ensure extras dir exists if needed
            if dest_folder == "extras":
                os.makedirs(os.path.join(PROJECT_ROOT, "extras"), exist_ok=True)

            try:
                shutil.move(src_path, dest_path)
                print(f"[MOVED] {file} -> {dest_folder}/")
                # Update hash map so we don't import the same file twice in one run if there are copies in source
                existing_hashes[file_hash] = dest_path
                moved_count += 1
            except Exception as e:
                print(f"Error moving {file}: {e}")

    print("\nOrganization Complete.")
    print(f"Processed: {processed_count}")
    print(f"Moved/Organized: {moved_count}")
    print(f"Duplicates found (ignored): {dupe_count}")


if __name__ == "__main__":
    import sys

    source = os.path.join(PROJECT_ROOT, SOURCE_FOLDER_NAME)

    # Allow override via args
    if len(sys.argv) > 1:
        source = sys.argv[1]

    print("==========================================")
    print("   TEMPORAL RAW DATA SORTER & DEDUPER     ")
    print("==========================================")
    process_raw_data(source)
