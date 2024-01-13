'use client';

import DashboardComponent from '../components/dashboard/Dashboard';
import isAuth from '../isAuth';

const Dashboard = () => (
  <DashboardComponent>
    <p>Dashboard</p>
  </DashboardComponent>
);

export default isAuth(Dashboard);
