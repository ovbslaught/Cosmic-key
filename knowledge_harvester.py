import os
import json
import re
from pathlib import Path

# Configuration
KNOWLEDGE_BASE_FILE = "echo_knowledge_base.json"
IGNORE_DIRS = {".git", "bin", "obj", "App_Data", ".vs", "node_modules"}
IGNORE_EXTENSIONS = {".dll", ".exe", ".zip", ".png", ".jpg", ".gif", ".tscn", ".import"}
TEXT_EXTENSIONS = {".txt", ".md", ".json", ".py", ".cs", ".js", ".ts"}

def load_knowledge_base():
    if os.path.exists(KNOWLEDGE_BASE_FILE):
        with open(KNOWLEDGE_BASE_FILE, 'r', encoding='utf-8') as f:
            return json.load(f)
    return {"rules": [], "memory": [], "patterns": {}}

def save_knowledge_base(kb):
    with open(KNOWLEDGE_BASE_FILE, 'w', encoding='utf-8') as f:
        json.dump(kb, f, indent=4)

def extract_concepts(text):
    # simple heuristic: look for capitalized phrases usually indicating entities or titles
    # excluding common code keywords
    concepts = set()
    # Regex for capitalized words (2 or more)
    matches = re.findall(r'\b[A-Z][a-z]+(?:\s+[A-Z][a-z]+)+\b', text)
    for m in matches:
        concepts.add(m)
    return list(concepts)

def harvest_knowledge():
    print("Initiating Knowledge Harvest protocols...")
    kb = load_knowledge_base()
    
    known_concepts = set()
    # Load existing concepts from rules/patterns to avoid dupes
    for rule in kb.get("rules", []):
        for inp in rule.get("input", []):
            known_concepts.add(inp.lower())
    
    new_concepts_found = 0
    files_scanned = 0

    for root, dirs, files in os.walk("."):
        # Filter directories
        dirs[:] = [d for d in dirs if d not in IGNORE_DIRS]
        
        for file in files:
            ext = os.path.splitext(file)[1].lower()
            if ext in TEXT_EXTENSIONS:
                files_scanned += 1
                try:
                    path = os.path.join(root, file)
                    with open(path, 'r', encoding='utf-8', errors='ignore') as f:
                        content = f.read()
                        
                    concepts = extract_concepts(content)
                    
                    for concept in concepts:
                        if concept.lower() not in known_concepts:
                            # Add a generic recognition rule for this new concept
                            new_rule = {
                                "input": [concept.lower()],
                                "output": f"Recognized entity '{concept}' from harvested data."
                            }
                            kb["rules"].append(new_rule)
                            known_concepts.add(concept.lower())
                            new_concepts_found += 1
                            print(f"[+] Harvested new concept: {concept}")

                except Exception as e:
                    print(f"Error reading {file}: {e}")

    if new_concepts_found > 0:
        save_knowledge_base(kb)
        print(f"\nHarvest complete. {files_scanned} files scanned.")
        print(f"Awakened to {new_concepts_found} new concepts.")
    else:
        print("\nHarvest complete. No new concepts found.")

if __name__ == "__main__":
    harvest_knowledge()
