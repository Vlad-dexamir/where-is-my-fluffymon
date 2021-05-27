import Typography from '@material-ui/core/Typography';
import Link from '@material-ui/core/Link';
import React from 'react';

export const Copyright: React.FC = () => (
  <Typography variant="body2" color="textSecondary" align="center">
    {'Copyright © '}
    <Link color="inherit" href="https://material-ui.com/">
      Where's my fluffymon?
    </Link>{' '}
    {new Date().getFullYear()}
    {'.'}
  </Typography>
);
