import React, { useEffect, useState } from 'react'
import ApiHelper from '../helpers/api';
import { Table} from 'react-bootstrap'

const ProductList=(props)=>{

    const [product, setProduct] = useState([]);
    useEffect(() => {
        ApiHelper.Products.getAll().then((res) => {
            setProduct(res)
        })
    },[])
    function display() {
        const getCategoryId = window.location.href.substring(31);
        product.map((pr)=>
            {if(pr.categoryId==getCategoryId)
            return(
                <div> {pr.name} {pr.description} {pr.price}</div>
            )
            return(
                <div> {getCategoryId}</div>
            )}
                );
        return(
            <div> {getCategoryId}</div>
            )
      }

    return (
        <div>
            <h2>Products</h2>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>ID #</th>
                        <th>Name</th>
                        <th>Description</th>
                        <th>Category</th>
                        <th>Price</th>
                        <th>Base Price</th>
                    </tr>
                </thead>
                <tbody>
                    {product.map((p) => (
                        <tr key={p.productId}>
                            <td>{p.productId}</td>
                            <td>{p.name}</td>
                            <td>{p.description}</td>
                            <td>{p.categoryId}</td>
                            <td>{p.price}</td>
                            <td>{p.basePrice}</td>
                        </tr>
                    ))}
                </tbody>
            </Table>
            <div></div>
            {product.map((pr)=>
            <div> {pr.name} {pr.description}</div>
            )}
            {display()}
            </div>
    )
}
export default ProductList;