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
        }
    }

    buscarConsultas = async () => {
        const resposta = await api.get('/');

        const dadosApi = resposta.data;
        this.setState({ listaConsultas: dadosApi });
    };

    componentDidMount() {
        this.buscarConsultas();
    }

    render() {
        return (
            <view>
                <view>
                    <text>Minhas Consultas</text>
                    <FlatList
                        contentContainerStyle={styles.mainBodyContent}
                        data={this.state.listaConsultas}
                        keyExtractor={item => item.idConsulta}
                        renderItem={this.renderItem} />
                </view>
            </view>
        );
    }

    renderItem = ({ item }) => (
        <view styles={styles.apoio_lista}>
            <view styles={styles.fundo_info} >
                <text style={styles.usuario_nome}></text>
                <text style={styles.consulta_especialidade}></text>
                <text style={styles.consulta_endereco}></text>
                <text style={styles.consulta_data}></text>
            </view>
        </view>
    )
}

const styles = StyleSheet.create({

});