import os
import time
import subprocess
from datetime import datetime

# Configuration
VAULT_PATH = os.path.join(os.path.dirname(os.path.abspath(__file__)), "Cosmic Vault")
STATUS_FILE = os.path.join(VAULT_PATH, "System Status.md")
CHAT_FILE = os.path.join(VAULT_PATH, "Cosmic Chat.md")
DASHBOARD_FILE = os.path.join(VAULT_PATH, "Dashboards", "Main Control.canvas")


def ensure_vault_structure():
    os.makedirs(os.path.join(VAULT_PATH, "Dashboards"), exist_ok=True)

    # Initialize Status File
    if not os.path.exists(STATUS_FILE):
        with open(STATUS_FILE, "w") as f:
            f.write("# 🖥️ Cosmic Key OS Status\n\nWaiting for sync...")

    # Initialize Chat File
    if not os.path.exists(CHAT_FILE):
        with open(CHAT_FILE, "w") as f:
            f.write(
                "# 💬 Cosmic Chat\n\n**User**: Hello System.\n\n**Cosmic Key**: Online and listening.\n\n---\n"
            )


def get_process_status(process_name):
    try:
        output = subprocess.check_output(
            f'tasklist /FI "IMAGENAME eq {process_name}"', shell=True
        ).decode()
        if process_name in output:
            return "🟢 Online"
        return "🔴 Offline"
    except:
        return "⚪ Unknown"


def update_status_markdown():
    iis_status = get_process_status("iisexpress.exe")
    python_status = get_process_status("python.exe")

    timestamp = datetime.now().strftime("%Y-%m-%d %H:%M:%S")

    content = f"""# 🖥️ Cosmic Key OS Status
**Last Updated**: {timestamp}

## 🚦 System Health
| Service | Status | Process |
| :--- | :--- | :--- |
| **Web Interface** | {iis_status} | `iisexpress.exe` |
| **AI / Background** | {python_status} | `python.exe` |

## 🔗 Quick Links
- [[Cosmic Chat]]
- [[Main Control.canvas]]
"""
    with open(STATUS_FILE, "w") as f:
        f.write(content)


def bridge_loop():
    print(f"Obsidian Bridge Active. Monitoring {VAULT_PATH}...")
    ensure_vault_structure()

    while True:
        try:
            update_status_markdown()
            time.sleep(5)
        except KeyboardInterrupt:
            break
        except Exception as e:
            print(f"Bridge Error: {e}")
            time.sleep(5)


if __name__ == "__main__":
    bridge_loop()
