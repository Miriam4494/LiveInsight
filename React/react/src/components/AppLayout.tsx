
// import { Outlet, Link } from 'react-router-dom';
// import { AppBar, Toolbar, Typography, Button, Box } from '@mui/material';

// const AppLayout = () => {
//   return (
//     <>
//       <AppBar position="sticky" sx={{ backgroundColor: '#1c1c1c', boxShadow: 'none' }}>
//         <Toolbar sx={{ display: 'flex', justifyContent: 'space-between' }}>
//           <Typography variant="h5" sx={{ fontWeight: 'bold', color: '#ffffff' }}>
//             Feedback System
//           </Typography>
//           <Box>
//             <Button component={Link} to="/" sx={navButtonStyle}>
//               Home
//             </Button>
//             <Button component={Link} to="/login" sx={navButtonStyle}>
//               Login
//             </Button>
//             <Button component={Link} to="/register" sx={navButtonStyle}>
//               Register
//             </Button>
//           </Box>
//         </Toolbar>
//       </AppBar>
//       <Outlet />
//     </>
//   );
// };

// const navButtonStyle = {
//   color: '#ffffff',
//   fontWeight: 'bold',
//   fontSize: '1rem',
//   marginLeft: 2,
//   '&:hover': { color: '#f4b400' }, // זהב עדין להדגשה
// };

// export default AppLayout;
// import { Outlet, Link } from 'react-router-dom';
// import { AppBar, Toolbar, Typography, Button, Box } from '@mui/material';

// const AppLayout = () => {
//   return (
//     <>
//       <AppBar
//         position="sticky"
//         sx={{
//           backgroundColor: 'rgba(28, 28, 28, 0.9)',
//           backdropFilter: 'blur(10px)',
//           boxShadow: '0px 4px 10px rgba(0, 0, 0, 0.5)',
//         }}
//       >
//         <Toolbar sx={{ display: 'flex', justifyContent: 'space-between' }}>
//           <Typography variant="h5" sx={{ fontWeight: 'bold', color: '#f4b400' }}>
//             Feedback System
//           </Typography>
//           <Box>
//             <Button component={Link} to="/" sx={navButtonStyle}>
//               Home
//             </Button>
//             <Button component={Link} to="/login" sx={navButtonStyle}>
//               Login
//             </Button>
//             <Button component={Link} to="/register" sx={navButtonStyle}>
//               Register
//             </Button>
//           </Box>
//         </Toolbar>
//       </AppBar>
//       <Outlet />
//     </>
//   );
// };

// const navButtonStyle = {
//   color: '#ffffff',
//   fontWeight: 'bold',
//   fontSize: '1rem',
//   marginLeft: 2,
//   transition: 'all 0.3s ease-in-out',
//   '&:hover': { color: '#f4b400', transform: 'scale(1.1)' }, // אנימציה קלה
// };

// export default AppLayout;




// import { Outlet, Link } from 'react-router-dom';
// import { AppBar, Toolbar, Typography, Button, Box } from '@mui/material';

// const AppLayout = () => {
//   return (
//     <>
//       <AppBar
//         position="sticky"
//         sx={{
//           background: 'linear-gradient(135deg, #111 30%, #222 100%)',
//           boxShadow: '0px 4px 15px rgba(0, 255, 255, 0.3)',
//         }}
//       >
//         <Toolbar sx={{ display: 'flex', justifyContent: 'space-between' }}>
//           <Typography variant="h5" sx={{ fontWeight: 'bold', color: '#00FFFF' }}>
//             Feedback System
//           </Typography>
//           <Box>
//             <Button component={Link} to="/" sx={navButtonStyle}>
//               Home
//             </Button>
//             <Button component={Link} to="/login" sx={navButtonStyle}>
//               Login
//             </Button>
//             <Button component={Link} to="/register" sx={navButtonStyle}>
//               Register
//             </Button>
//           </Box>
//         </Toolbar>
//       </AppBar>
//       <Outlet />
//     </>
//   );
// };

// const navButtonStyle = {
//   color: '#FFD700', // זהב מטאלי
//   fontWeight: 'bold',
//   fontSize: '1rem',
//   marginLeft: 2,
//   transition: 'all 0.3s ease-in-out',
//   '&:hover': { color: '#00FFFF', transform: 'scale(1.1)' },
// };

// export default AppLayout;


// import { Outlet, Link } from 'react-router-dom';
// import { AppBar, Toolbar, Typography, Button, Box } from '@mui/material';

// const AppLayout = () => {
//   return (
//     <>
//       <AppBar
//         position="sticky"
//         sx={{
//           background: '#121212', // שחור עמוק
//           boxShadow: '0px 4px 15px rgba(255, 215, 0, 0.3)', // צל זהוב עדין
//         }}
//       >
//         <Toolbar sx={{ display: 'flex', justifyContent: 'space-between' }}>
//           <Typography variant="h5" sx={{ fontWeight: 'bold', color: '#FFD700' }}>
//             Feedback System
//           </Typography>
//           <Box>
//             <Button component={Link} to="/" sx={navButtonStyle}>
//               Home
//             </Button>
//             <Button component={Link} to="/login" sx={navButtonStyle}>
//               Login
//             </Button>
//             <Button component={Link} to="/register" sx={navButtonStyle}>
//               Register
//             </Button>
//             <Button component={Link} to="/L" sx={navButtonStyle}>
//               l
//             </Button>
//           </Box>
//         </Toolbar>
//       </AppBar>
//       <Outlet />
//     </>
//   );
// };

// const navButtonStyle = {
//   color: '#FFD700', // זהב
//   fontWeight: 'bold',
//   fontSize: '1rem',
//   marginLeft: 2,
//   transition: 'all 0.3s ease-in-out',
//   '&:hover': { color: '#E6C200', transform: 'scale(1.1)' },
// };

// export default AppLayout;
import { useState } from 'react';
import { Outlet, Link } from 'react-router-dom';
import { AppBar, Toolbar, Typography, Button, Box } from '@mui/material';
import AuthPopup from './AuthPopup';  // וודא שאתה מייבא את ה-AuthPopup

const AppLayout = () => {
  const [isAuthPopupOpen, setIsAuthPopupOpen] = useState(false);  // סטייט לשליטה על הפופאפ

  return (
    <>
      <AppBar
        position="sticky"
        sx={{
          background: '#121212', // שחור עמוק
          boxShadow: '0px 4px 15px rgba(255, 215, 0, 0.3)', // צל זהוב עדין
        }}
      >
        <Toolbar sx={{ display: 'flex', justifyContent: 'space-between' }}>
          <Typography variant="h5" sx={{ fontWeight: 'bold', color: '#FFD700' }}>
            Feedback System
          </Typography>
          <Box>
            <Button component={Link} to="/" sx={navButtonStyle}>
              Home
            </Button>
            {/* <Button component={Link} to="/login" sx={navButtonStyle}>
              Login
            </Button>
            <Button component={Link} to="/register" sx={navButtonStyle}>
              Register
            </Button> */}
            <Button sx={navButtonStyle} onClick={() => setIsAuthPopupOpen(true)}>
              l
            </Button>
          </Box>
        </Toolbar>
      </AppBar>

      {/* אם הסטייט של הפופאפ פתוח, נציג את ה-AuthPopup */}
      {isAuthPopupOpen && <AuthPopup onClose={() => setIsAuthPopupOpen(false)} />}

      <Outlet />
    </>
  );
};

const navButtonStyle = {
  color: '#FFD700', // זהב
  fontWeight: 'bold',
  fontSize: '1rem',
  marginLeft: 2,
  transition: 'all 0.3s ease-in-out',
  '&:hover': { color: '#E6C200', transform: 'scale(1.1)' },
};

export default AppLayout;
