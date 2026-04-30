import json
import csv
import os
import re

def load_json(file):
    try:
        if not os.path.exists(file):
            return []
        with open(file, "r") as f:
            return json.load(f)
    except Exception:
        return []

def save_json(file, data):
    with open(file, "w") as f:
        json.dump(data, f, indent=4)

def backup_to_csv(data):
    if not data:
        return
    with open("data/backup.csv", "w", newline="") as f:
        writer = csv.DictWriter(f, fieldnames=data[0].keys())
        writer.writeheader()
        writer.writerows(data)

def validate_name(name):
    return bool(re.match("^[A-Za-z ]+$", name))

def ticket_generator(tickets):
    for t in tickets:
        yield t