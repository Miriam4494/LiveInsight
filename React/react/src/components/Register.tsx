import  { useState } from 'react';
import axios from 'axios';
import { TextField, Button, Box, Typography } from '@mui/material';
import { useNavigate } from 'react-router-dom'; // שינוי מ-useHistory ל-useNavigate

const Register = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate(); // חיבור ל-useNavigate

  const handleRegister = async () => {
    if (password !== confirmPassword) {
      setError('Passwords do not match.');
      return;
    }

    try {
      const response = await axios.post('https://localhost:7230/api/auth/register', {
        email,
        password
      });

      const data = response.data;

      if (response.status === 201) {
        navigate('/login'); // ניווט לדף ההתחברות אחרי הרשמה מוצלחת
      } else {
        setError(data.message);
      }
    } catch (err) {
      setError('Registration failed. Please try again.');
    }
  };

  return (
    <Box sx={{ width: 300, margin: 'auto', padding: 3 }}>
      <Typography variant="h5" gutterBottom>
        Register
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
      <TextField
        label="Confirm Password"
        type="password"
        fullWidth
        value={confirmPassword}
        onChange={(e) => setConfirmPassword(e.target.value)}
        margin="normal"
      />
      {error && <Typography color="error">{error}</Typography>}
      <Button fullWidth variant="contained" onClick={handleRegister} sx={{ marginTop: 2 }}>
        Register
      </Button>
    </Box>
  );
};

export default Register;
