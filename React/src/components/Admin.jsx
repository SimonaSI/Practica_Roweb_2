import React from 'react'
import "bootstrap/dist/css/bootstrap.min.css";
import "../Styles/button.css";
import CategoriesList from '../components/CategoriesList'
import "bootstrap/js/src/collapse.js";
import AddProductForm  from './AddProductForm'
function Admin() {
    return (
        <div>
        <CategoriesList/>
        <AddProductForm/>
        </div>
    )}
export default Admin