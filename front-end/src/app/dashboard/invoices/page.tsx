import DashboardComponent from "../../components/dashboard/Dashboard";
import InvoicesList from "../../components/dashboard/invoices/InvoicesList";

export default function Dashboard() {
    return (
        <DashboardComponent>
            <InvoicesList />
        </DashboardComponent>
    )
}