import React, { Component } from 'react';
import {
    Image,
    StatusBar,
    StyleSheet,
    View,
} from 'react-native';

import { createBottomTabNavigator } from '@react-navigation/bottom-tabs';

const bottomTab = createBottomTabNavigator();

import Listar from './listar';
import Perfil from './perfil';

export default class Main extends Component {

    render() {
        return (
            <view>
                <buttonTab.Navigator

                    initialRouteName='Listar'

                    screenOptions={({ route }) => ({
                        tabBarIcon: () => {

                            if (route.name === 'Listar') {
                                return (
                                    <image
                                        source={require('../../assets/img/Iconelista.png')}
                                    />
                                )
                            }

                            if (route.name === 'Perfil') {
                                return (
                                    <image
                                        source={require('../../assets/img/IconePerfil.png')}
                                    />
                                )
                            }
                        },

                        headerShown: false,
                        tabBarShowLabel: false,
                        tabBarActiveBackgroundColor: '#B727FF',
                        tabBarInactiveBackgroundColor: '#DD99FF',
                        tabBarStyle: { height: 50 }
                    })}
                >

                    <buttonTab.Screen name="Listar" Component={Listar} />
                    <buttonTab.Screen name="Perfil" Component={Perfil} />

                </buttonTab.Navigator>
            </view>
        );

    }
};

const styles = StyleSheet.create({

});

