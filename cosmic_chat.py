import os

# import sys # unused
import json
import urllib.request
import urllib.error
from typing import Dict, Any, Optional

# Configuration
DOTENV_PATH = os.path.join(os.path.dirname(os.path.abspath(__file__)), ".env")

# Provider Definitions
PROVIDERS = {
    "1": {
        "name": "Gemini (Google)",
        "env_var": "GEMINI_API_KEY",
        "endpoint": "https://generativelanguage.googleapis.com/v1beta/models/gemini-pro:generateContent?key={KEY}",
        "type": "google",
    },
    "2": {
        "name": "Perplexity",
        "env_var": "PERPLEXITY_API_KEY",
        "endpoint": "https://api.perplexity.ai/chat/completions",
        "model": "llama-3.1-sonar-small-128k-online",
        "type": "openai_compat",
    },
    "3": {
        "name": "Grok (xAI)",
        "env_var": "GROK_API_KEY",
        "endpoint": "https://api.x.ai/v1/chat/completions",
        "model": "grok-beta",
        "type": "openai_compat",
    },
    "4": {
        "name": "Mistral",
        "env_var": "MISTRAL_API_KEY",
        "endpoint": "https://api.mistral.ai/v1/chat/completions",
        "model": "mistral-tiny",
        "type": "openai_compat",
    },
    "5": {
        "name": "DeepSeek",
        "env_var": "DEEPSEEK_API_KEY",
        "endpoint": "https://api.deepseek.com/chat/completions",
        "model": "deepseek-chat",
        "type": "openai_compat",
    },
    "6": {
        "name": "OpenRouter (Universal)",
        "env_var": "OPENROUTER_API_KEY",
        "endpoint": "https://openrouter.ai/api/v1/chat/completions",
        "model": "openai/gpt-3.5-turbo",  # Default, can be changed
        "type": "openai_compat",
    },
}


class CosmicChat:
    def __init__(self):
        self.api_keys: Dict[str, str] = self.load_keys()
        self.history = []

    def load_keys(self) -> Dict[str, str]:
        keys = {}
        if os.path.exists(DOTENV_PATH):
            with open(DOTENV_PATH, "r") as f:
                for line in f:
                    if "=" in line:
                        k, v = line.strip().split("=", 1)
                        keys[k] = v
        # Also check OS env
        for k, v in os.environ.items():
            keys[k] = v
        return keys

    def get_api_key(self, env_var: str) -> Optional[str]:
        return self.api_keys.get(env_var)

    def send_google_request(self, provider, message):
        key = self.api_keys.get(provider["env_var"])
        if not key:
            return "Error: API Key not found."

        data = {"contents": [{"parts": [{"text": message}]}]}

        url = provider["endpoint"].replace("{KEY}", key)
        req = urllib.request.Request(
            url,
            data=json.dumps(data).encode("utf-8"),
            headers={"Content-Type": "application/json"},
        )

        try:
            with urllib.request.urlopen(req) as response:
                result = json.loads(response.read().decode())
                # Safe navigation
                try:
                    return result["candidates"][0]["content"]["parts"][0]["text"]
                except (KeyError, IndexError):
                    return f"Unexpected response format: {result}"
        except urllib.error.HTTPError as e:
            return f"HTTP Error: {e.code} - {e.read().decode()}"
        except Exception as e:
            return f"Error: {e}"

    def send_openai_compat_request(self, provider, message):
        key = self.api_keys.get(provider["env_var"])
        if not key:
            return "Error: API Key not found."

        data = {
            "model": provider["model"],
            "messages": [
                {
                    "role": "system",
                    "content": "You are a helpful assistant in the Cosmic Key OS environment.",
                },
                {"role": "user", "content": message},
            ],
            "stream": False,
        }

        headers = {"Content-Type": "application/json", "Authorization": f"Bearer {key}"}

        req = urllib.request.Request(
            provider["endpoint"], data=json.dumps(data).encode("utf-8"), headers=headers
        )

        try:
            with urllib.request.urlopen(req) as response:
                result = json.loads(response.read().decode())
                try:
                    return result["choices"][0]["message"]["content"]
                except (KeyError, IndexError):
                    return f"Unexpected response format: {result}"
        except urllib.error.HTTPError as e:
            return f"HTTP Error: {e.code} - {e.read().decode()}"
        except Exception as e:
            return f"Error: {e}"

    def log_to_vault(self, provider_name, user_text, ai_response):
        """Logs the conversation to the Obsidian Vault for sync."""
        vault_path = os.path.join(
            os.path.dirname(os.path.abspath(__file__)), "Cosmic Vault", "Cosmic Chat.md"
        )

        timestamp = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
        entry = f"\n\n#### {timestamp} | {provider_name}\n**You**: {user_text}\n\n**Cosmic**: {ai_response}\n\n---"

        try:
            # Ensure folder exists (just in case)
            os.makedirs(os.path.dirname(vault_path), exist_ok=True)

            with open(vault_path, "a", encoding="utf-8") as f:
                f.write(entry)
        except Exception as e:
            print(f"[Log Error]: {e}")

    def chat_loop(self):
        print("\n=== COSMIC CHAT MATRIX ===")

        # Check if we have ANY keys
        if not self.api_keys:
            print("\n[!] NO API KEYS FOUND.")
            print("To enable AI chat, you need to configure your API keys.")
            print("1. Run 'DEPLOY_UNIFIED.bat' and select Option [8] Setup.")
            print("2. Or manually add keys to your 'keyz' folder.")
            input("\nPress Enter to exit...")
            return

        print("Select Provider:")
        available_indices = []
        for pid, p in PROVIDERS.items():
            has_key = (
                " [READY]" if self.api_keys.get(p["env_var"]) else " [MISSING KEY]"
            )
            print(f"{pid}. {p['name']}{has_key}")
            available_indices.append(pid)

        choice = input("\nSelect Provider ID: ").strip()
        if choice not in PROVIDERS:
            print("Invalid selection.")
            return

        provider = PROVIDERS[choice]
        print(f"\nInitializing link to {provider['name']}...")

        if not self.api_keys.get(provider["env_var"]):
            print(f"WARNING: Key ({provider['env_var']}) missing.")
            print("Please run Option [8] (Setup) in the main menu to configure it.")
            input("Press Enter to continue...")
            return

        print("Connection established. Type 'exit' to quit.\n")

        while True:
            user_input = input("You > ")
            if user_input.lower() in ["exit", "quit"]:
                break

            print("Cosmic Key > Thinking...", end="\r")

            response = ""
            if provider["type"] == "google":
                response = self.send_google_request(provider, user_input)
            elif provider["type"] == "openai_compat":
                response = self.send_openai_compat_request(provider, user_input)

            # Clear thinking line
            print(" " * 20, end="\r")
            print(f"Cosmic Key > {response}\n")

            # Log to Obsidian
            self.log_to_vault(provider["name"], user_input, response)


if __name__ == "__main__":
    chat = CosmicChat()
    chat.chat_loop()
