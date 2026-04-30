from utils import load_json
from collections import Counter

class ReportGenerator:

    @staticmethod
    def daily_report():
        tickets = load_json("data/tickets.json")

        total = len(tickets)
        open_t = len([t for t in tickets if t["status"]=="Open"])
        closed = len([t for t in tickets if t["status"]=="Closed"])
        high = len([t for t in tickets if t["priority"]=="P1"])

        print("Daily Report")
        print("Total:", total)
        print("Open:", open_t)
        print("Closed:", closed)
        print("High Priority:", high)

    @staticmethod
    def monthly_report():
        tickets = load_json("data/tickets.json")

        # 🔥 filter usage
        high_priority = list(filter(lambda t: t["priority"] == "P1", tickets))

        # 🔥 map usage
        high_ids = list(map(lambda t: t["ticket_id"], high_priority))

        issues = [t["issue"] for t in tickets]
        most_common = Counter(issues).most_common(1)

        depts = [t["dept"] for t in tickets]
        top_dept = Counter(depts).most_common(1)

        print("\nMonthly Report")
        print("Most Common Issue:", most_common)
        print("Top Department:", top_dept)
        print("High Priority Count:", len(high_priority))
        print("High Priority Ticket IDs:", high_ids)