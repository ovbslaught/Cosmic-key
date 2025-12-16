import time

# import os # unused
import subprocess
import sys
import logging
# from datetime import datetime # unused

# Configuration
LOG_FILE = "cosmic_watchdog.log"
POLL_INTERVAL = 30  # seconds

logging.basicConfig(
    filename=LOG_FILE,
    level=logging.INFO,
    format="%(asctime)s - %(levelname)s - %(message)s",
)


class CosmicWatchdog:
    def __init__(self):
        self.running = True
        self.services = {"IIS Express": "iisexpress.exe"}

    def log(self, message):
        print(f"[Watchdog] {message}")
        logging.info(message)

    def check_services(self):
        # Simple check using tasklist on Windows
        try:
            output = subprocess.check_output("tasklist", shell=True).decode()
            for name, exe in self.services.items():
                if exe in output:
                    # self.log(f"{name} is running.")
                    pass
                else:
                    self.log(f"ALERT: {name} is NOT running.")
                    # self.restart_service(name) # Auto-restart logic would go here
        except Exception as e:
            self.log(f"Error checking services: {e}")

    def run_code_snippet(self, code_str):
        """Ability for system to run its own code safely-ish."""
        self.log("Executing dynamic code snippet...")
        try:
            exec(code_str)
            self.log("Code executed successfully.")
        except Exception as e:
            self.log(f"Code execution failed: {e}")

    def loop(self):
        self.log("Cosmic Watchdog started. Monitoring system...")
        while self.running:
            try:
                self.check_services()

                # Daemon could check for a 'command.json' file to execute instructions
                # if os.path.exists("cosmic_command.json"): ...

                time.sleep(POLL_INTERVAL)
            except KeyboardInterrupt:
                self.log("Stopping Watchdog.")
                self.running = False

    def self_test(self):
        self.log("Performing self-test...")
        # Verify internet connectivity or other criticals
        return True


if __name__ == "__main__":
    dog = CosmicWatchdog()

    if len(sys.argv) > 1 and sys.argv[1] == "--active":
        dog.loop()
    else:
        dog.log("Watchdog initialized. Run with --active to monitor.")
