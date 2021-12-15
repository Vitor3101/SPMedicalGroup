import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, View } from 'react-native';

import api from '../services/api';

import { TouchableOpacity } from 'react-native-gesture-handler';

import AsyncStorage from '@react-native-async-storage/async-storage';

export default class Listar extends Component {
    constructor(props) {
        super(props);
        this.state = {
            listaConsultas: [],
        };
    }

    buscarConsultas = async () => {
        const resposta = await api.get('/Consulta');

        const dadosApi = resposta.data;
        this.setState({ listaConsultas: dadosApi });
    };

    componentDidMount() {
        this.buscarConsultas();
    }

    render() {
        return (
            <View style={styles.main}>
                <View style={styles.lista}>
                    <Text style={styles.titulo}>Minhas Consultas</Text>
                    <FlatList
                        contentContainerStyle={styles.mainBodyContent}
                        data={this.state.listaConsultas}
                        keyExtractor={item => item.idConsulta}
                        renderItem={this.renderItem}
                    />
                </View>
            </View>
        );
    }

    renderItem = ({ item }) => (
        <View style={styles.apoio_lista}>
            <View style={styles.fundo_info}>
                <Text style={styles.usuario_nome}>{item.idMedicoNavigation.idUsuarioNavigation.Nome}</Text>
                <Text style={styles.consulta_especialidade}>{item.idMedicoNavigation.idEspecialidadeNavigation.especialidade1}</Text>
                <Text style={styles.consulta_endereco}>{item.idMedicoNavigation.idClinicaNavigation.Endereco}</Text>
                <Text style={styles.consulta_data}>{item.dataConsulta}</Text>
            </View>
        </View>
    )
}

const styles = StyleSheet.create({

    main: {
        backgroundColor: '#5CD17F',
        height: '100%',
        width: '100%',
        alignItems: 'center'
    },

    lista: {
        width: '80%'
    },

    titulo: {
        alignSelf: 'center'
    },

    apoio_lista: {
        backgroundColor: '#55C276',
        height: '40%'
    },

    fundo_info: {
        alignItems: 'center'
    }


});