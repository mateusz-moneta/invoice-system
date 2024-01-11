import LeftMenu from "./LeftMenu";

export default function DashboardComponent({children}) {
    return (
        <>
            <LeftMenu />
            <div className="p-4 sm:ml-64">
                {children}
            </div>
        </>
    )
}