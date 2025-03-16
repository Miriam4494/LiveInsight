import  { useState } from 'react';
import axios from 'axios';
import { TextField, Button, Box, Typography } from '@mui/material';
import { useNavigate } from 'react-router-dom'; // שינוי מ-useHistory ל-useNavigate

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate(); // חיבור ל-useNavigate

  const handleLogin = async () => {
    try {
      const response = await axios.post('https://localhost:7230/api/auth/login', {
        email,
        password
      });

      const data = response.data;

      if (response.status === 200) {
        localStorage.setItem('token', data.token);
        navigate('/dashboard'); // שימוש ב-navigate במקום history.push
      } else {
        setError(data.message);
      }
    } catch (err) {
      setError('Login failed. Please try again.');
    }
  };

  return (
    <Box sx={{ width: 300, margin: 'auto', padding: 3 }}>
      <Typography variant="h5" gutterBottom>
        Login
      </Typography>
      <TextField
        label="Email"
        fullWidth
        value={email}
        onChange={(e) => setEmail(e.target.value)}
        margin="normal"
      />
      <TextField
        label="Password"
        type="password"
        fullWidth
        value={password}
        onChange={(e) => setPassword(e.target.value)}
        margin="normal"
      />
      {error && <Typography color="error">{error}</Typography>}
      <Button fullWidth variant="contained" onClick={handleLogin} sx={{ marginTop: 2 }}>
        Login
      </Button>
    </Box>
  );
};

export default Login;
