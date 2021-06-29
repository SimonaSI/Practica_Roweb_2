import React from 'react'
import "bootstrap/dist/css/bootstrap.min.css";
import "../Styles/button.css";
import CategoriesList from '../components/CategoriesList'
import "bootstrap/js/src/collapse.js";
import AddProduct  from './AddProduct'
function Admin() {
    return (
        <div>
        <CategoriesList/>
        <AddProduct/>
        </div>
    )}
export default Admin