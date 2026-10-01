import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './app/layout/styles.css'
//Material UI Roboto Font:
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import { RouterProvider } from 'react-router-dom';
import { router } from './app/routes/Routes.tsx';
import { Provider } from 'react-redux';
import { store } from './app/store/store';
import { ToastContainer } from 'react-toastify';
import 'react-toastify/ReactToastify.css'



createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <Provider store={store}>/*makes the Redux store available to React components*/
      <ToastContainer position='bottom-right' hideProgressBar theme='colored' />
      <RouterProvider router={router} />
    </Provider>
    
  </StrictMode>,
)
