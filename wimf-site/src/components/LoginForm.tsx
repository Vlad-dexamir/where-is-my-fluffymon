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
import {Copyright} from "./elements/Copyright";
import {Context} from "../Context";
import {CreatePostPayload, PostType} from "../core/domain/Post/Post";
import {AuthorizeUserPayload} from "../core/domain/User";

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

export const LoginForm = () => {
  const classes = useStyles();

  const [email, updateEmail] = useState('');
  const [password, updatePassword] = useState('');

  const login = async () => {
    if(!email && !password) {
      await Context.alertService.fire({
        icon: 'error',
        title: 'Ooops....',
        text: 'Please complete all fields',
        showCloseButton: true,
        showConfirmButton: true,
      })
      return;
    }

    const payload: AuthorizeUserPayload = {
     email,
      password,
    };

    try {
      const response = await Context.apiService.authorizeUser(payload);

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
          Login
        </Typography>
        <form className={classes.form} noValidate>
          <Grid container spacing={1}>
            <Grid item xs={12}>
              <TextField
                variant="outlined"
                fullWidth
                id="email"
                label="Email Address or Phone Number"
                name="Email"
                onChange={(e) => updateEmail(e.target.value)}
              />
            </Grid>
            <Grid item xs={12}>
              <TextField
                variant="outlined"
                fullWidth
                name="password"
                label="Password"
                type="password"
                id="password"
                autoComplete="current-password"
                onChange={(e) => updatePassword(e.target.value)}
              />
            </Grid>
          </Grid>
          <Button
            type="button"
            fullWidth
            variant="contained"
            color="primary"
            className={classes.submit}
            onClick={login}
          >
            Login
          </Button>
        </form>
      </div>
      <Box mt={5}>
        <Copyright />
      </Box>
    </Container>
  );
};
