from datetime import datetime, timedelta
from utils import *
from logger import *

class Ticket:
    def __init__(self, emp_name, dept, issue, category):
        self.ticket_id = f"T{int(datetime.now().timestamp())}"
        self.emp_name = emp_name
        self.dept = dept
        self.issue = issue
        self.category = category
        self.priority = self.set_priority()
        self.__status = "Open"
        self.created = str(datetime.now())

    def set_priority(self):
        rules = {
            "Server Down": "P1",
            "Internet Down": "P2",
            "Laptop Slow": "P3",
            "Password Reset": "P4"
        }
        return rules.get(self.category, "P3")

    def get_status(self):
        return self.__status

    def set_status(self, status):
        self.__status = status

    def to_dict(self):
        return {
            "ticket_id": self.ticket_id,
            "emp_name": self.emp_name,
            "dept": self.dept,
            "issue": self.issue,
            "category": self.category,
            "priority": self.priority,
            "status": self.__status,
            "created": self.created
        }

class IncidentTicket(Ticket):
    pass

class ServiceRequest(Ticket):
    pass

class TicketManager:
    def __init__(self):
        self.tickets = load_json("data/tickets.json")

    def create_ticket(self, ticket):
        self.tickets.append(ticket.to_dict())
        save_json("data/tickets.json", self.tickets)
        log_info(f"Ticket Created: {ticket.ticket_id}")
        print("✅ Ticket Created Successfully")

    def view_tickets(self):
        if not self.tickets:
            print("No tickets found")
        for t in ticket_generator(self.tickets):
            print(t)

    def search_ticket(self, tid):
        for t in self.tickets:
            if t["ticket_id"] == tid:
                return t
        raise Exception("Ticket not found")

    # ✅ FIXED INDENTATION HERE
    def update_status(self, tid, status):
        for t in self.tickets:
            if t["ticket_id"] == tid:
                t["status"] = status
                save_json("data/tickets.json", self.tickets)
                log_info(f"Updated {tid}")
                print("✅ Ticket Updated Successfully")
                return
        raise Exception("Invalid ID")

    def delete_ticket(self, tid):
        found = False
        for t in self.tickets:
            if t["ticket_id"] == tid:
                found = True

        if not found:
            raise Exception("Invalid ID")

        self.tickets = [t for t in self.tickets if t["ticket_id"] != tid]
        save_json("data/tickets.json", self.tickets)
        log_warning(f"Deleted {tid}")
        print("🗑️ Ticket Deleted Successfully")

    def check_sla(self):
        sla_rules = {"P1":1, "P2":4, "P3":8, "P4":24}
        breached = False

        for t in self.tickets:
            created = datetime.strptime(t["created"], "%Y-%m-%d %H:%M:%S.%f")
            limit = created + timedelta(hours=sla_rules[t["priority"]])

            if datetime.now() > limit and t["status"] != "Closed":
                print("⚠ SLA Breached:", t["ticket_id"])
                log_warning(f"SLA breach: {t['ticket_id']}")
                breached = True

        if not breached:
            print("✅ No SLA breaches")