import { useState } from 'react'
import './App.css';
import PublicRoutes from './routes/PublicRoutes'

function App() {
  console.log("API URL:", import.meta.env.VITE_API_BASE_URL);

  return (
    <>
      
      <PublicRoutes/>
    </>
    
  )
}

export default App
