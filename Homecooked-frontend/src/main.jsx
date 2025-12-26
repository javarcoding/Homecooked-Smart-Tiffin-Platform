import { BrowserRouter } from 'react-router-dom'
import { Provider } from 'react-redux'
import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import App from './App.jsx'
import { store } from './store/store.js';



// 🔽 TEMPORARY TEST (SUBTASK 19.4)
import axiosInstance from "./api/axiosInstance";
import authService from "./api/services/authService";




authService.login({
  email: "admin123@gmail.com",
  password: "Admin@123",
})
.then(res => console.log(res))
.catch(err => console.error(err));

// 🔼 REMOVE AFTER TESTING

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <Provider store={store}>
      <BrowserRouter>
        <App />
      </BrowserRouter>
    </Provider>
  </StrictMode>,
)
