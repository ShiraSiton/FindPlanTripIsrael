import { RouterProvider, createBrowserRouter } from 'react-router';
import Layout from '../layouts/Layout';
import HomePage from '../pages/HomePage';
import LoginPage from '../pages/LoginPage';
import { Paths } from './paths';
import RegisterPage from '../pages/RegisterPage';
import DayTripsPage from '../pages/DayTripsPage';
import TripDetailsPage from '../pages/TripDetailsPage';
import AuthGuard from '../auth/AuthGuard';
import PersonalArea from '../pages/PersonalArea';
import TripPlannerWizard from '../pages/TripPlannerWizard';
import PlanningResultPage from '../pages/PlanningResultPage';
import AboutPage from '../pages/AboutPage';
import ContactPage from '../pages/ContactPage';

const Routes = () => {
  const router = createBrowserRouter([
    {
      path: '/',
      element: <Layout />,
      children: [
        {
          index: true,
          element: <HomePage />,
        },
        {
          path: 'about',
          element: <AboutPage />,
        },
        {
          path: 'contact',
          element: <ContactPage />,
        },
        {
          path: Paths.trips,
          element: <DayTripsPage />,
        },
        {
          path: Paths.tripsDetail,
          element: <TripDetailsPage />,
        },
        {
          path: Paths.user,
          element: <AuthGuard><PersonalArea /></AuthGuard>,
        },
        {
          path: Paths.tripPlan,
          element: <TripPlannerWizard />,
        },
        {
          path: Paths.planningResultPage,
          element: <PlanningResultPage />,
        },
      ],
    },

    {
      path: Paths.login,
      element: <LoginPage />,
    },
    {
      path: Paths.register,
      element: <RegisterPage />,
    },
    {
      path: '*',
      element: <h1>404 Page not found</h1>,
    },
  ]);

  return <RouterProvider router={router} />;
};

export default Routes;
