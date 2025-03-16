import { Dispatch, SetStateAction, useState } from 'react';
import axios from 'axios';
import { TextField, Button, Box, Typography, Paper, IconButton } from '@mui/material';
import CloseIcon from '@mui/icons-material/Close';
import { useNavigate } from 'react-router-dom';

const AuthPopup = ({ onClose }: { onClose: Dispatch<SetStateAction<boolean>> }) => {

  const [isLogin, setIsLogin] = useState(true);
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [confirmPassword, setConfirmPassword] = useState('');
  const [error, setError] = useState('');
  const navigate = useNavigate();

  const handleSubmit = async () => {
    if (!isLogin && password !== confirmPassword) {
      setError('Passwords do not match');
      return;
    }

    try {
      const endpoint = isLogin ? 'login' : 'register';
      const response = await axios.post(`https://localhost:7230/api/auth/${endpoint}`, { email, password });

      if (response.status === 200) {
        if (isLogin) {
          localStorage.setItem('token', response.data.token);
          navigate('/dashboard');
          onClose(false); // סוגר את הפופאפ אחרי התחברות
        } else {
          setIsLogin(true); // לאחר הרשמה, נוודא שהמשתמש עובר למצב התחברות
        }
      } else {
        setError(response.data.message || 'An error occurred');
      }
    } catch (err) {
      setError('Authentication failed. Please try again.');
    }
  };

  return (
    <Box sx={overlayStyle}>
      <Paper elevation={10} sx={paperStyle}>
        <Box sx={headerStyle}>
          <Typography variant="h5" sx={titleStyle}>{isLogin ? 'Login' : 'Register'}</Typography>
          <IconButton onClick={() => onClose(false)} sx={closeButtonStyle}><CloseIcon /></IconButton>
        </Box>
        <TextField label="Email" fullWidth value={email} onChange={(e) => setEmail(e.target.value)} margin="normal" />
        <TextField label="Password" type="password" fullWidth value={password} onChange={(e) => setPassword(e.target.value)} margin="normal" />
        {!isLogin && (
          <TextField label="Confirm Password" type="password" fullWidth value={confirmPassword} onChange={(e) => setConfirmPassword(e.target.value)} margin="normal" />
        )}
        {error && <Typography color="error" sx={{ textAlign: 'center', mb: 2 }}>{error}</Typography>}
        <Button fullWidth variant="contained" onClick={handleSubmit} sx={buttonStyle}>
          {isLogin ? 'Login' : 'Register'}
        </Button>
        <Typography variant="body2" sx={switchTextStyle} onClick={() => setIsLogin(!isLogin)}>
          {isLogin ? "Don't have an account? Register" : "Already have an account? Login"}
        </Typography>
      </Paper>
    </Box>
  );
};

const overlayStyle = {
  position: 'fixed',
  top: 0,
  left: 0,
  width: '100vw',
  height: '100vh',
  background: 'rgba(0, 0, 0, 0.6)',
  display: 'flex',
  justifyContent: 'center',
  alignItems: 'center',
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

const headerStyle = {
  display: 'flex',
  justifyContent: 'space-between',
  alignItems: 'center',
};

const closeButtonStyle = {
  color: 'white',
};

const titleStyle = {
  fontWeight: 'bold',
  color: '#FFD700',
  mb: 2,
};

const buttonStyle = {
  mt: 2,
  backgroundColor: '#FFD700',
  color: '#000',
  fontWeight: 'bold',
  '&:hover': { backgroundColor: '#E6C200' },
};

const switchTextStyle = {
  mt: 2,
  cursor: 'pointer',
  color: '#FFD700',
};

export default AuthPopup;
