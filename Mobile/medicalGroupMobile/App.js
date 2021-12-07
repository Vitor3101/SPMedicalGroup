import React from 'react';

import {
  SafeAreaView,
  ScrollView,
  StatusBar,
  StyleSheet,
  Text,
  View,
} from 'react-native';

import {
  Colors,
  Header,
} from 'react-native/Libraries/NewAppScreen';

import { NavigationContainer } from '@react-navigation/native';
import { createStackNavigator } from '@react-navigation/stack';

const AuthStack = createStackNavigator();

import Main from './src/screens/main'
import Listar from './src/screens/listar'
import Login from './src/screens/login'

export default function Stack() {

  return (
    <NavigationContainer>
      <StatusBar
        hidden={true} />

      <AuthStack.Navigator
        initialRouteName="Login"
        screenOptions={{
          HeaderShown: false,
        }}>
      </AuthStack.Navigator>


      <AuthStack.Screen name="Login" component={Login} />
      <AuthStack.Screen name="Main" component={Main} />
      <AuthStack.Screen name="Listar" component={Listar} />

    </NavigationContainer>
  );
}

const styles = StyleSheet.create({

});