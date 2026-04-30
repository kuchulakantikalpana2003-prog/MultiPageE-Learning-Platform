import logging
import os

if not os.path.exists("data"):
    os.makedirs("data")

logging.basicConfig(
    filename="data/logs.txt",
    level=logging.DEBUG,
    format="%(asctime)s - %(levelname)s - %(message)s"
)

def log_info(msg): logging.info(msg)
def log_warning(msg): logging.warning(msg)
def log_error(msg): logging.error(msg)
def log_critical(msg): logging.critical(msg)