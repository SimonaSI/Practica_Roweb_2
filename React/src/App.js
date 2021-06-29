
import "./App.css";
import ProductList from "./components/ProductList";
import Sidebar from "./components/Sidebar";
import { Container, Row, Col } from "react-bootstrap";
import { Route, Switch } from "react-router-dom";
import "bootstrap/dist/css/bootstrap.min.css";
import Admin from "./components/Admin";
import Products from './components/Products'

function App() {
  return (
    <Container fluid>
      <Row>
        <Col lg={2} id="sidebar-wrapper" className="d-none d-sm-block">
        <Sidebar/>
        </Col>
        <Col lg={10} xs={12} id="page-content-wrapper">
        <Switch>
            <Route path="/products/:id"  render={(props) => <ProductList  />} />
            <Route path="/admin" render={(props) =><Admin/>}/>
            <Route path="/home" render={(props)=><Products/>}/>
          </Switch>
        </Col>
      </Row>
      
    </Container>

  );
}

export default App;
