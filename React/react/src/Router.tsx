// router.js
import { createBrowserRouter } from 'react-router-dom';
 // המסך הראשי שמכיל את ה-Layout הכללי
import Login from './components/Login';          // דף ההתחברות
import Dashboard from './components/Dashboard';  // דף הלוח בקרה
import Register from './components/Register';    // דף הרישום
import AppLayout from './components/AppLayout';

// יצירת הראוטינג עם כל הנתיבים
export const Router = createBrowserRouter([
  {
    path: '/',
    element: <AppLayout />,  // Layout מרכזי שבו כל שאר הקומפוננטות יוטמעו
    errorElement: <h1>Error. Please try later...</h1>,  // במקרה של שגיאה
    children: [
      { path: '/', element: <Login /> },  // דף התחברות
      { path: 'dashboard', element: <Dashboard /> },  // דף לוח בקרה
      { path: 'register', element: <Register /> },  // דף רישום
    ],
  },
]);
