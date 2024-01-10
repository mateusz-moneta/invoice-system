import DashboardComponent from "../../components/dashboard/Dashboard";
import CustomersList from "../../components/dashboard/customers/CustomersList";

export default function DashboardCustomers() {
    return (
        <DashboardComponent>
            <CustomersList />
        </DashboardComponent>
    )
}