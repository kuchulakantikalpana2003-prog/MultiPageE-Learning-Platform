import psutil
from tickets import TicketManager, IncidentTicket
from logger import *

def monitor_system():
    cpu = psutil.cpu_percent()
    ram = psutil.virtual_memory().percent
    disk = psutil.disk_usage('/').percent

    print(f"CPU:{cpu}, RAM:{ram}, Disk:{disk}")

    if cpu > 90 or ram > 95 or disk > 90:
        tm = TicketManager()
        t = IncidentTicket("System", "IT", "High Usage", "Server Down")
        tm.create_ticket(t)
        log_critical("Auto ticket created")