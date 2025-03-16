
import { Link } from 'react-router-dom';  // ייבוא ליצירת קישורים

const AppLayout = () => {
  return (
    <div>
      <nav>
        <ul>
          <li><Link to="/">Login</Link></li>
          <li><Link to="/dashboard">Dashboard</Link></li>
          <li><Link to="/register">Register</Link></li>
        </ul>
      </nav>
      <div>
        {/* כאן כל תוכן הדפים יתממשק */}
      </div>
    </div>
  );
};

export default AppLayout;
