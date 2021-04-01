import React from "react";
import {useFormik} from "formik";
import * as yup from "yup";
import Button from "@material-ui/core/Button";
import TextField from "@material-ui/core/TextField";
import {LoginFormWrapper} from "./LoginFormStyles";

const validationSchema = {
    email: yup.string().email().required(),
    password: yup.string()
        .min(8, "Password must have minimum 8 characters")
        .max(32, "Password must have maximum 8 characters")
};

const initialValues = {
    email: "",
    password: "",
};

export const LoginForm = () => {
    const handleSubmit = (values:any) => {
        console.log(values);
    };

    const formik = useFormik({
        initialValues,
        onSubmit: handleSubmit,
    });

    return(
        <LoginFormWrapper>
            <TextField
                id="#email"
                name="email"
                label="Email"
                value ={formik.values.email}
                onChange={formik.handleChange}
                type="email"
                />
            <TextField
                id="#password"
                name="password"
                label="Password"
                value ={formik.values.password}
                onChange={formik.handleChange}
                type="password"

            />

            <Button color ="primary" variant="contained" type="submit">
                Login
            </Button>

        </LoginFormWrapper>
    )
}