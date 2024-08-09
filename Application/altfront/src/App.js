import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import Register from './components/Register';
import Login from './components/Login';
import Dashboard from './components/Dashboard';

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/user" element={<Register />} />
        <Route path="/user" element={<Login />} />
        <Route path="/board" element={<Dashboard />} />
        <Route path="/board/{id}" element={<Board />} />

        
      </Routes>
    </Router>
  );
}

export default App;
