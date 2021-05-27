import React, {useState} from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import { Copyright } from './elements/Copyright';
import {Context} from "../Context";
import {CreatePostPayload, PostType} from "../core/domain/Post/Post";
import {CreateUserPayload} from "../core/domain/User";

const useStyles = makeStyles((theme) => ({
  paper: {
    marginTop: theme.spacing(0),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
  avatar: {
    margin: theme.spacing(1),
    backgroundColor: theme.palette.secondary.main,
  },
  form: {
    width: '100%', // Fix IE 11 issue.
    marginTop: theme.spacing(3),
  },
  submit: {
    margin: theme.spacing(3, 0, 2),
  },
}));

export const RegisterForm: React.FC = () => {
  const classes = useStyles();

  const [email, updateEmail] = useState('');
  const [password, updatePassword] = useState('');
  const [firstName, updateFirstName] = useState('');
  const [lastName, updateLastName] = useState('');
  const [phoneNumber, updatePhoneNumber] = useState('');

  const register = async() => {
    if(!email && !password && !firstName) {
      await Context.alertService.fire({
        icon: 'error',
        title: 'Ooops....',
        text: 'Your post is not valid, please complete all fields',
        showCloseButton: true,
        showConfirmButton: true,
      })
      return;
    }

    const payload: CreateUserPayload = {
      firstName,
      lastName,
      email,
      password,
      phoneNumber,
      location: {
        lat: 12232,
        lng: 23243,
      }
    };

    try {
      const response = await Context.apiService.createUser(payload);

      if(response) {
        localStorage.setItem('jwtToken', response);
      }

    } catch (e) {
      console.error(e);
      await Context.alertService.fire({
        icon: 'error',
        title: 'Oops...',
        text: e.message,
      });
    }
  }

  return (
    <Container component="main" maxWidth="xs">
      <CssBaseline />
      <div className={classes.paper}>
        <Avatar className={classes.avatar}>
          <LockOutlinedIcon />
        </Avatar>
        <Typography component="h1" variant="h5">
          Register
        </Typography>
        <form className={classes.form} noValidate>
          <Grid container spacing={1}>
            <Grid item xs={12} sm={6}>
              <TextField
                autoComplete="fname"
                name="firstName"
                variant="outlined"
                required
                fullWidth
                id="firstName"
                label="First Name"
                autoFocus
                onChange={(e)=> updateFirstName(e.target.value)}
              />
            </Grid>
            <Grid item xs={12} sm={6}>
              <TextField
                variant="outlined"
                required
                fullWidth
                id="lastName"
                label="Last Name"
                name="lastName"
                autoComplete="lname"
                onChange={(e)=> updateLastName(e.target.value)}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                variant="outlined"
                required
                fullWidth
                id="email"
                label="Email Address"
                name="email"
                autoComplete="email"
                onChange={(e)=> updateEmail(e.target.value)}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                variant="outlined"
                required
                fullWidth
                name="password"
                label="Password"
                type="password"
                id="password"
                autoComplete="current-password"
                onChange={(e)=> updatePassword(e.target.value)}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                variant="outlined"
                required
                fullWidth
                name="cpassword"
                label="Confirm Password"
                type="password"
                id="confirmPassword"
                autoComplete="current-password"
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                variant="outlined"
                fullWidth
                id="phone"
                label="Phone Number"
                name="phone"
                autoComplete="phone"
                onChange={(e)=> updatePhoneNumber(e.target.value)}
              />
            </Grid>
          </Grid>
          <Button
            type="button"
            fullWidth
            variant="contained"
            color="primary"
            className={classes.submit}
            onClick={register}
          >
            Register
          </Button>
        </form>
      </div>
      <Box mt={5}>
        <Copyright />
      </Box>
    </Container>
  );
};
