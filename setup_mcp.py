import os
import json
# import shutil  # unused

# Configuration
PROJECT_ROOT = os.path.dirname(os.path.abspath(__file__))
DOTENV_PATH = os.path.join(PROJECT_ROOT, ".env")
MCP_CONFIG_PATH = os.path.join(PROJECT_ROOT, "mcp_config.json")

# Mapping of Keyz filename to Env Var
KEY_MAPPING = {
    "gemini api key.txt": "GEMINI_API_KEY",
    "ollamaapikey.txt": "OLLAMA_API_KEY",
    "openrouter api key.txt": "OPENROUTER_API_KEY",
    "Elevenlabs api.txt": "ELEVENLABS_API_KEY",
    "Docker key.txt": "DOCKER_AUTH_KEY",
}


def setup_environment(keyz_path):
    print(f"Scanning KEYZ at: {keyz_path}")

    env_vars = {}

    if not os.path.exists(keyz_path):
        print("KEYZ folder not found.")
        return

    # Read keys
    for filename, env_var in KEY_MAPPING.items():
        file_path = os.path.join(keyz_path, filename)
        if os.path.exists(file_path):
            try:
                with open(file_path, "r", encoding="utf-8") as f:
                    # simplistic reading: take first line, strip whitespace
                    value = f.read().strip()
                    if value:
                        env_vars[env_var] = value
                        print(f"[+] Loaded {filename} -> {env_var}")
            except Exception as e:
                print(f"Error reading {filename}: {e}")
        else:
            print(f"[-] Missing {filename}")

    # Write .env
    print(f"Writing credentials to {DOTENV_PATH}...")
    with open(DOTENV_PATH, "w", encoding="utf-8") as f:
        for k, v in env_vars.items():
            f.write(f"{k}={v}\n")

    return env_vars


def generate_mcp_config(env_vars):
    print("Generating MCP Configuration...")

    # Example MCP Config Structure
    mcp_config = {"mcpServers": {}}

    # Add servers based on available keys
    if "GEMINI_API_KEY" in env_vars:
        mcp_config["mcpServers"]["gemini"] = {
            "command": "python",
            "args": ["mcp-servers/gemini_server.py"],
            "env": {"GEMINI_API_KEY": env_vars["GEMINI_API_KEY"]},
        }

    if "OLLAMA_API_KEY" in env_vars:
        # Assuming Ollama might run locally or remote with key
        mcp_config["mcpServers"]["ollama"] = {
            "command": "python",
            "args": ["mcp-servers/ollama_server.py"],
            "env": {"OLLAMA_API_KEY": env_vars["OLLAMA_API_KEY"]},
        }

    if "OPENROUTER_API_KEY" in env_vars:
        mcp_config["mcpServers"]["openrouter"] = {
            "command": "python",
            "args": ["mcp-servers/openrouter_server.py"],
            "env": {"OPENROUTER_API_KEY": env_vars["OPENROUTER_API_KEY"]},
        }

    with open(MCP_CONFIG_PATH, "w", encoding="utf-8") as f:
        json.dump(mcp_config, f, indent=4)
    print(f"MCP Config written to {MCP_CONFIG_PATH}")


if __name__ == "__main__":
    import sys

    # Default search paths if not provided
    default_paths = [
        r"c:\runnerapps\COSMIC-KEY\geologos\BLOG\KEYZ",
        r"c:\Users\ovbsl\Documents\KEYZ",
    ]

    target_path = None
    if len(sys.argv) > 1:
        target_path = sys.argv[1]

    # Interactive fallback or auto-discovery
    if not target_path or not os.path.exists(target_path):
        for p in default_paths:
            if os.path.exists(p):
                target_path = p
                break

    if not target_path:
        target_path = input("Enter path to KEYZ folder: ").strip("'\"")

    if target_path:
        vars = setup_environment(target_path)
        if vars:
            generate_mcp_config(vars)

            # Ensure .env is gitignored
            gitignore = os.path.join(PROJECT_ROOT, ".gitignore")
            if os.path.exists(gitignore):
                with open(gitignore, "r") as f:
                    if ".env" not in f.read():
                        print("Adding .env to .gitignore...")
                        with open(gitignore, "a") as gf:
                            gf.write("\n.env\n")
            else:
                with open(gitignore, "w") as gf:
                    gf.write(".env\n")
    else:
        print("No valid KEYZ path provided.")
