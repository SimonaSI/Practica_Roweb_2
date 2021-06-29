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
            <CardDeck className="cardDeck">
             {
               product.map((p)=>(
                 <div className="col" >
                 <Card className="productCard">
                      <Card.Img variant="top" src={p.image} className="image"/>
                      <Card.Body>
                      <Card.Text className="cardText">
                          <p className="card-text-el">{p.name}</p>
                          <p className="card-text-el">{p.description}</p>
                          <p className="card-text-el basePrice"> {p.basePrice}</p>  
                          <h2 className="card-text-el">{p.price}</h2>
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