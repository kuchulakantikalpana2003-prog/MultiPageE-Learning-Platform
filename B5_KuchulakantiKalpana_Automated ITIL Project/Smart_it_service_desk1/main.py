from tickets import *
from monitor import monitor_system
from reports import ReportGenerator
from itil import problem_management, change_log
from utils import validate_name, backup_to_csv

def menu():
    tm = TicketManager()

    while True:
        print("\n1.Create\n2.View\n3.Search\n4.Update\n5.Delete\n6.Monitor\n7.Report\n8.SLA\n9.Backup\n10.Exit")
        ch = input("Choice: ")

        try:
            if ch == "1":
                name = input("Name: ")
                if not validate_name(name):
                    raise Exception("Invalid Name")

                dept = input("Dept: ")
                issue = input("Issue: ")
                cat = input("Category: ")

                t = IncidentTicket(name, dept, issue, cat)
                tm.create_ticket(t)

            elif ch == "2":
                tm.view_tickets()

            elif ch == "3":
                print(tm.search_ticket(input("ID: ")))

            elif ch == "4":
                tm.update_status(input("ID: "), input("Status: "))

            elif ch == "5":
                tm.delete_ticket(input("ID: "))

            elif ch == "6":
                monitor_system()

            elif ch == "7":
                ReportGenerator.daily_report()
                ReportGenerator.monthly_report()

            elif ch == "8":
                tm.check_sla()

            elif ch == "9":
                backup_to_csv(tm.tickets)

            elif ch == "10":
                break

        except Exception as e:
            print("Error:", e)

if __name__ == "__main__":
    menu()