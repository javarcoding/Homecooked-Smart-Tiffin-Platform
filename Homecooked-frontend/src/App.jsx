import { useState } from 'react'
import './App.css';
import PublicRoutes from './routes/PublicRoutes'

function App() {
  
  return (
    <>
      console.log("API URL:", import.meta.env.VITE_API_BASE_URL);

      <PublicRoutes/>
    </>
    
  )
}

export default App
