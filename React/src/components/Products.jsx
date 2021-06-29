import React,{useState,useEffect} from 'react';
import ApiHelper from '../helpers/api';
import { Card, CardDeck} from 'react-bootstrap'
import "bootstrap/dist/css/bootstrap.min.css";
import "../Styles/prod.css";

const Products=(props)=>{

    const [product,setProduct] = useState([]);
    useEffect(() => {
      ApiHelper.Products.getAll().then((res)=>{
        setProduct(res)
      })
    },[]);

    return(
      <div className="container">
          <div className="row">
            <CardDeck>
             {
               product.map((p)=>(
                 <div className="col-lg-3" >
                 <Card >
                  <Card.Img variant="top" src={p.image} className="image"/>
                  <Card.Body>
                  <Card.Text>
                      {p.name} {p.description}
                      <h2>{p.price}</h2>
                  </Card.Text>
                  </Card.Body>
                   </Card>
                   </div>
                   ))
             }
            </CardDeck>              
          </div>
      </div>
    )}
export default Products