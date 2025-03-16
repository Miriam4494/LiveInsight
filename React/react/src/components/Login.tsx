// // components/Login.js
// import { useState } from 'react';
// import axios from 'axios';
// import { TextField, Button, Box, Typography } from '@mui/material';
// import { useNavigate } from 'react-router-dom';

// const Login = () => {
//   const [email, setEmail] = useState('');
//   const [password, setPassword] = useState('');
//   const [error, setError] = useState('');
//   const navigate = useNavigate();

//   const handleLogin = async () => {
//     try {
//       const response = await axios.post('https://localhost:7230/api/auth/login', { email, password });
//       if (response.status === 200) {
//         localStorage.setItem('token', response.data.token);
//         navigate('/dashboard');
//       } else {
//         setError('Invalid login details');
//       }
//     } catch (err) {
//       setError('Login failed. Please try again.');
//     }
//   };
//   console.log("login");

//   return (
//     <Box sx={{ width: 300, margin: 'auto', padding: 3 }}>
//       <Typography variant="h5" gutterBottom>Login</Typography>
//       <TextField label="Email" fullWidth value={email} onChange={(e) => setEmail(e.target.value)} margin="normal" />
//       <TextField label="Password" type="password" fullWidth value={password} onChange={(e) => setPassword(e.target.value)} margin="normal" />
//       {error && <Typography color="error">{error}</Typography>}
//       <Button fullWidth variant="contained" onClick={handleLogin} sx={{ marginTop: 2 }}>
//         Login
//       </Button>
//     </Box>
//   );
// };

// export default Login;

// components/Login.js
import { useState } from 'react';
import axios from 'axios';
import { TextField, Button, Box, Typography, Paper } from '@mui/material';
import { useNavigate } from 'react-router-dom';

const Login = () => {
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleLogin = async () => {
    try {
      const response = await axios.post('https://localhost:7230/api/auth/login', { email, password });
      if (response.status === 200) {
        localStorage.setItem('token', response.data.token);
        navigate('/dashboard');
      } else {
        setError('שם משתמש או סיסמה שגויים');
      }
    } catch (err) {
      setError('ההתחברות נכשלה. נסה שוב.');
    }
  };

  return (
    <Box sx={containerStyle}>
      <Paper elevation={10} sx={paperStyle}>
        <Typography variant="h4" sx={titleStyle}>התחברות</Typography>
        <TextField label="אימייל" fullWidth value={email} onChange={(e) => setEmail(e.target.value)} margin="normal" />
        <TextField label="סיסמה" type="password" fullWidth value={password} onChange={(e) => setPassword(e.target.value)} margin="normal" />
        {error && <Typography color="error" sx={{ textAlign: 'center', mb: 2 }}>{error}</Typography>}
        <Button fullWidth variant="contained" onClick={handleLogin} sx={buttonStyle}>
          התחבר
        </Button>
      </Paper>
    </Box>
  );
};

const containerStyle = {
  display: 'flex',
  justifyContent: 'center',
  alignItems: 'center',
  height: '100vh',
  background: 'linear-gradient(to right, #111, #222)',
};

const paperStyle = {
  padding: 4,
  borderRadius: 3,
  maxWidth: 400,
  width: '100%',
  backdropFilter: 'blur(15px)',
  background: 'rgba(255, 255, 255, 0.1)',
  boxShadow: '0px 4px 20px rgba(255, 215, 0, 0.3)',
  color: '#FFF',
  textAlign: 'center',
  border: '1px solid rgba(255, 215, 0, 0.3)',
};

const titleStyle = { fontWeight: 'bold', color: '#FFD700', mb: 3 };

const buttonStyle = {
  mt: 2,
  backgroundColor: '#FFD700',
  color: '#000',
  fontWeight: 'bold',
  '&:hover': { backgroundColor: '#E6C200' },
};

export default Login;
