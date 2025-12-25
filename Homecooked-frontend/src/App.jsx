import { useState } from 'react'
import './App.css';
import PublicRoutes from './routes/PublicRoutes'

function App() {
  const [count, setCount] = useState(0)

  return (
    <PublicRoutes/>
  )
}

export default App
