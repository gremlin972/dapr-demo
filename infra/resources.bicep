param name string
param location string
param principalId string = ''
param resourceToken string
param tags object
param baconImageName string = ''
param eggsImageName string = ''
param toastImageName string = ''
param deliveryImageName string = ''
param checkoutImageName string = ''

module containerAppsResources './containerapps.bicep' = {
  name: 'containerapps-resources'
  params: {
    location: location
    tags: tags
    resourceToken: resourceToken
  }

  dependsOn: [
    serviceBusResources
    logAnalyticsResources
  ]
}

module keyVaultResources './keyvault.bicep' = {
  name: 'keyvault-resources'
  params: {
    location: location
    tags: tags
    resourceToken: resourceToken
    principalId: principalId
  }
}

module serviceBusResources './servicebus.bicep' = {
  name: 'sb-resources'
  params: {
    location: location
    tags: tags
    resourceToken: resourceToken
    skuName: 'Standard'
  }
}

module appInsightsResources './appinsights.bicep' = {
  name: 'appinsights-resources'
  params: {
    location: location
    tags: tags
    resourceToken: resourceToken
  }
}

module checkoutResources './checkout.bicep' = {
  name: 'api-resources'
  params: {
    name: name
    location: location
    imageName: checkoutImageName != '' ? checkoutImageName : 'nginx:latest'
  }
  dependsOn: [
    containerAppsResources
    appInsightsResources
    keyVaultResources
    serviceBusResources
  ]
}

module baconResources './bacon.bicep' = {
  name: 'web-resourcesb'
  params: {
    name: name
    location: location
    imageName: baconImageName != '' ? baconImageName : 'nginx:latest'
  }
  dependsOn: [
    containerAppsResources
    appInsightsResources
    keyVaultResources
    serviceBusResources
  ]
}

module eggsResources './eggs.bicep' = {
  name: 'web-resourcese'
  params: {
    name: name
    location: location
    imageName: eggsImageName != '' ? eggsImageName : 'nginx:latest'
  }
  dependsOn: [
    containerAppsResources
    appInsightsResources
    keyVaultResources
    serviceBusResources
  ]
}

module toastResources './toast.bicep' = {
  name: 'web-resourcest'
  params: {
    name: name
    location: location
    imageName: toastImageName != '' ? toastImageName : 'nginx:latest'
  }
  dependsOn: [
    containerAppsResources
    appInsightsResources
    keyVaultResources
    serviceBusResources
  ]
}

module deliveryResources './delivery.bicep' = {
  name: 'web-resourcesd'
  params: {
    name: name
    location: location
    imageName: deliveryImageName != '' ? deliveryImageName : 'nginx:latest'
  }
  dependsOn: [
    containerAppsResources
    appInsightsResources
    keyVaultResources
    serviceBusResources
  ]
}

module logAnalyticsResources './loganalytics.bicep' = {
  name: 'loganalytics-resources'
  params: {
    location: location
    tags: tags
    resourceToken: resourceToken
  }
}

output AZURE_COSMOS_CONNECTION_STRING_KEY string = 'AZURE-COSMOS-CONNECTION-STRING'
output AZURE_KEY_VAULT_ENDPOINT string = keyVaultResources.outputs.AZURE_KEY_VAULT_ENDPOINT
output SERVICEBUS_ENDPONT string = serviceBusResources.outputs.SERVICEBUS_ENDPOINT
output APPINSIGHTS_INSTRUMENTATIONKEY string = appInsightsResources.outputs.APPINSIGHTS_INSTRUMENTATIONKEY
output AZURE_CONTAINER_REGISTRY_ENDPOINT string = containerAppsResources.outputs.AZURE_CONTAINER_REGISTRY_ENDPOINT
output AZURE_CONTAINER_REGISTRY_NAME string = containerAppsResources.outputs.AZURE_CONTAINER_REGISTRY_NAME
output CHECKOUT_APP_URI string = checkoutResources.outputs.CHECKOUT_URI
output BACON_APP_URI string = baconResources.outputs.ORDERS_URI
output EGGS_APP_URI string = eggsResources.outputs.ORDERS_URI
output TOAST_APP_URI string = toastResources.outputs.ORDERS_URI
output DELIVERY_APP_URI string = deliveryResources.outputs.ORDERS_URI
