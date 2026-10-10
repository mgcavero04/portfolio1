import { Button, Divider, Grid2, Table, TableBody, TableCell, TableContainer, TableRow, TextField, Typography } from "@mui/material";
import { useFetchProductDetailsQuery } from "./catalogApi";
import { Link, useParams } from "react-router-dom";


export default function productDetails() {//component mounts
  // eslint-disable-next-line react-hooks/rules-of-hooks
  const {id} = useParams();
  // eslint-disable-next-line react-hooks/rules-of-hooks
  const {data: product, isLoading} = useFetchProductDetailsQuery(id ? +id : 0);//hook from RTK query to fetch product details from the API
  if (isLoading || !product) return <h3>Loading...</h3>
  const productDetails=[
    {label: 'Name', value:product?.name},
    {label: 'Description', value:product?.description},
    {label: 'Type', value:product?.type},
    {label: 'Brand', value:product?.brand},
    {label: 'Quantity in stock', value:product?.quantityInStock}
  ]
  return (
     <Grid2 container spacing={6} maxWidth='lg' sx={{ mx: 'auto' }}>
      <Grid2 size={6}>
        <img src={product?.pictureUrl} alt={product?.name} style={{ width: '100%' }} />
      </Grid2>
      <Grid2 size={6}>
        <Typography variant="h3">{product?.name}</Typography>
        <Divider sx={{ mb: 2 }} />
        <Typography variant="h4" color='secondary'>${product?.price !== undefined ? (product.price / 100).toFixed(2) : '0.00'}</Typography>
        <TableContainer>
          <Table sx={{'& td': {fontSize: '1rem'}}}>
            <TableBody>
                {productDetails.map((detail, index)=> (
                  <TableRow key={index}>
                    <TableCell sx={{fontweight: 'bold'}}>{detail.label}
                    </TableCell>
                     <TableCell>{detail.value}</TableCell>
                  </TableRow>
                ))}
            </TableBody>
          </Table>
        </TableContainer>
        <Grid2 container spacing={2} marginTop={3}>
          <Grid2 size={6}>
            <TextField
              variant="outlined"
              type="number"
              label='Quantity in basket'
              fullWidth
              defaultValue={1}
              
            />
          </Grid2>
          <Grid2 size={6}>
            <Button
              sx={{height: '55px'}}
              color="primary"
              size="large"
              variant="contained"
              fullWidth
            >
             Add to basket
            </Button>
          </Grid2>
        </Grid2>
        <Link to={product.url} target="_blank" rel="noopener noreferrer">
          View on Browser
        </Link>
      </Grid2>
    </Grid2>
  )
}