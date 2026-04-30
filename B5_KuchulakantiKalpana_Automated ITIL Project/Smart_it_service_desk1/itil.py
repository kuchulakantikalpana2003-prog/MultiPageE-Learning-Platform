from collections import Counter
from utils import *

def problem_management():
    tickets = load_json("data/tickets.json")
    issues = [t["issue"] for t in tickets]

    count = Counter(issues)
    problems = []

    for issue, c in count.items():
        if c >= 5:
            problems.append({"issue": issue, "count": c})

    save_json("data/problems.json", problems)

def change_log(change_desc):
    with open("data/logs.txt", "a") as f:
        f.write(f"CHANGE: {change_desc}\n")