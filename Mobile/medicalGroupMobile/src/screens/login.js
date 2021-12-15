import React, { Component } from 'react'

import {
    StyleSheet,
    Text,
    TouchableOpacity,
    View,
    Image,
    ImageBackground,
    TextInput,
} from 'react-native';

import logo from '../../assets/img/SPMedical_Logo.png'

import { useNavigation } from "@react-navigation/native";

import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class Login extends Component {
    constructor(props) {
        super(props);
        this.state = {
            email: 'Admin@Admin.com',
            senha: 'Admin123'
        };
    }

    realizarLogin = async () => {
        const resposta = await api.post('/Login', {
            email: this.state.email,
            senha: this.state.senha,
        });
        const token = resposta.data.token;
        await AsyncStorage.setItem('userToken', token);

        if (resposta.status == 200) {
            console.warn("Login Concluido com sucesso")
            this.props.navigation.navigate('Listar');
        }
    };

    render() {
        return (
            <View
                style={styles.fundoLogin}>
                <Image
                    source={logo}
                    style={styles.logoSp}
                />
                <View style={styles.apoioForm}>

                    <TextInput
                        style={styles.inputLogin}
                        placeholder="Email"
                        keyboardType="email-address"
                        onChangeText={email => this.setState({ email })}
                    />

                    <TextInput
                        style={styles.inputLogin}
                        placeholder="Senha"
                        keyboardType="default"
                        secureTextEntry={true}
                        onChangeText={senha => this.setState({ senha })}
                    />

                    <TouchableOpacity
                        style={styles.btnLogin}
                        onPress={this.realizarLogin}
                    >
                        <Text style={styles.btnLoginText}>Entrar</Text>
                    </TouchableOpacity>
                </View>
            </View>
        )
    }
}
const styles = StyleSheet.create({

    fundoLogin: {
        backgroundColor: '#3B8752',
        width: '100%',
        height: '100%',
        alignItems: 'center',
        justifyContent: 'space-between'
    },

    logoSp: {
        width: '43%',
        height: '30%',
        marginTop: '15%'
    },

    apoioForm: {
        width: '75%',
        height: '30%',
        justifyContent: 'space-between',
        alignItems: 'center',
        marginBottom: '25%'
    },

    inputLogin: {
        backgroundColor: '#fff',
        marginTop: 20,
        width: '100%',
        height: '25%',
        borderRadius: 10,
    },

    btnLogin: {
        backgroundColor: '#5CD17F',
        width: '40%',
        height: '20%',
        alignItems: 'center',
        justifyContent: 'center',
        color: 'fff',
        borderRadius: 10,
        marginTop: '10%'
    },
});