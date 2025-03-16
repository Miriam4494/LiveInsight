
import { RouterProvider } from 'react-router-dom'
import './App.css'

import { Router } from './Router'

function App() {

  return (
    <>
          <RouterProvider router={Router} />  // מחברים את הראוטינג לאפליקציה

    </>
  )
}

export default App
