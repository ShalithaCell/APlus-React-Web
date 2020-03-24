import React from 'react';
import CssBaseline from '@material-ui/core/CssBaseline';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import ButtonGroup from '@material-ui/core/ButtonGroup';

const useStyles = makeStyles((theme) => ({
  root : {
    height : '100vh'

  },
  paper : {
    margin : theme.spacing(8, 4),

    display : 'flex',

    flexDirection : 'column',

    alignItems : 'center'
  },
  cardGrid : {
    paddingTop : theme.spacing(8),

    paddingBottom : theme.spacing(8)
  },
  card : {
    height : '100%',

    display : 'flex',

    flexDirection : 'column'
  },
  cardMedia : {
    paddingTop : '56.25%' // 16:9
  },
  cardContent : {
    flexGrow : 1
  }
}));

const cards = [ 1, 2, 3, 4, 5, 6, 7, 8, 9 ];

export default function SignInSide() {
      const classes = useStyles();

  return (
      <Grid container component="main" className={ classes.root }>
          <CssBaseline />
          <Grid item xs={ false } sm={ 4 } md={ 7 }>
              <div className={ classes.paper }>
                  <ButtonGroup variant="contained" color="primary" aria-label="contained primary button group">
                      <Button>1</Button>
                      <Button>2</Button>
                      <Button>3</Button>
                      <Button>Qty</Button>
                  </ButtonGroup>
                  <ButtonGroup variant="contained" color="primary" aria-label="contained primary button group">
                      <Button>4</Button>
                      <Button>5</Button>
                      <Button>6</Button>
                      <Button>Disc</Button>
                  </ButtonGroup>
                  <ButtonGroup variant="contained" color="primary" aria-label="contained primary button group">
                      <Button>7</Button>
                      <Button>8</Button>
                      <Button>9</Button>
                      <Button>Price</Button>
                  </ButtonGroup>
                  <ButtonGroup variant="contained" color="primary" aria-label="contained primary button group">
                      <Button>+</Button>
                      <Button>0</Button>
                      <Button>-</Button>
                      <Button>Del</Button>
                  </ButtonGroup>
              </div>
          </Grid>

          <Grid item xs={ 12 } sm={ 8 } md={ 5 } component={ Paper } elevation={ 6 } square>
              <div className={ classes.paper }>
                  <Container className={ classes.cardGrid } maxWidth="md">
                      {/* End hero unit */}
                      <Grid container spacing={ 4 }>
                          { cards.map((card) => (
                              <Grid item key={ card } xs={ 12 } sm={ 6 } md={ 4 }>
                                  <Card className={ classes.card }>
                                      <CardMedia
                    className={ classes.cardMedia }
                    image="https://source.unsplash.com/random"
                    title="Image title"
                  />
                                      <CardContent className={ classes.cardContent }>
                                          <Typography gutterBottom variant="h5" component="h2">
                                            Coca cola
                                          </Typography>
                                          <Typography>
                                             This is a Coca cola You can buy it using debit card.
                                          </Typography>
                                      </CardContent>
                                      <CardActions>
                                          <Button size="small" color="primary">
                                            Buy
                                          </Button>
                                          <Button size="small" color="primary">
                                            Ignore
                                          </Button>
                                      </CardActions>
                                  </Card>
                              </Grid>
            ))}
                      </Grid>
                  </Container>
              </div>
          </Grid>
      </Grid>
  );
 }