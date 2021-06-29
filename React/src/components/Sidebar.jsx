import React, { useState, useEffect } from "react";
import { Nav } from "react-bootstrap";
import { Link } from "react-router-dom";
import ApiHelpers from "../helpers/api";
import "../Styles/sidebar.css";
const Sidebar = (props) => {
  const [categories, setCategories] = useState([]);

  useEffect(() => {
    ApiHelpers.ProductCategories.all().then((mappedApiCategories) => {
      setCategories(mappedApiCategories);
    });
  }, [props]);

  return (
    <Nav className="col-md-12 d-md-block bg-light sidebar">
      <div className="sidebar-sticky"></div>
      <Nav.Item>
        <Nav.Link as={Link} to={`/Home`}>Home</Nav.Link>
      </Nav.Item>
      {categories.map((c) => (
        <Nav.Item key={c.categoryId}>
          <Nav.Link key={c.categoryId} as={Link} to={`/products/${c.categoryId}`}>
            {c.name}
          </Nav.Link>
        </Nav.Item>
        
      ))}
       
        <Nav.Item><Nav.Link as={Link}  to={`/admin`} > Admin
        </Nav.Link>
        </Nav.Item>

    </Nav>
  );
};

export default Sidebar;
