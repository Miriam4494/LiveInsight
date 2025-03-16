import { useState, useEffect } from 'react';
import axios from 'axios';
import { Box, Typography, Button } from '@mui/material';
import { useNavigate } from 'react-router-dom';  // השתמש ב-useNavigate במקום useHistory
import { UserType } from '../types/User';

const Dashboard = () => {
  const [user, setUser] = useState<UserType | null>(null);  // הסטייט עבור UserType
  const [error, setError] = useState('');
  const navigate = useNavigate();  // יצירת הפונקציה navigate

  useEffect(() => {
    const token = localStorage.getItem('token');
    
    if (!token) {
      navigate('/login'); // אם אין token, העבר לדף ההתחברות
    } else {
      const fetchUserData = async () => {
        try {
          const response = await axios.get('https://localhost:7230/api/user', {
            headers: {
              Authorization: `Bearer ${token}`,
            },
          });

          const userData: UserType = response.data; // כאן ממירים את המידע ל- UserType
          setUser(userData);
        } catch (err) {
          setError('Failed to fetch user data.');
        }
      };

      fetchUserData();
    }
  }, [navigate]);

  const handleLogout = () => {
    localStorage.removeItem('token');
    navigate('/login'); // שימוש ב- navigate לעבור לדף ההתחברות
  };

  return (
    <Box sx={{ width: 300, margin: 'auto', padding: 3 }}>
      <Typography variant="h5" gutterBottom>
        Welcome to Dashboard
      </Typography>
      {error && <Typography color="error">{error}</Typography>}
      {user ? (
        <div>
          <Typography variant="h6">Hello, {user.firstName} {user.lastName}!</Typography>
          <Button fullWidth variant="contained" onClick={handleLogout} sx={{ marginTop: 2 }}>
            Logout
          </Button>
        </div>
      ) : (
        <Typography>Loading...</Typography>
      )}
    </Box>
  );
};

export default Dashboard;
