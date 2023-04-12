targetScope = 'subscription'

@minLength(1)
@maxLength(64)
@description('Name of the the environment which is used to generate a short unqiue hash used in all resources.')
param name string

@minLength(1)
@description('Primary location for all resources')
param location string

@description('Id of the user or app to assign application roles')
param principalId string = ''

@description('The image name for the checkout service')
param checkoutImageName string = ''

@description('The image name for the bacon-processor service')
param baconImageName string = ''

@description('The image name for the eggs-processor service')
param eggsImageName string = ''

@description('The image name for the toast-processor service')
param toastImageName string = ''

@description('The image name for the delivery service')
param deliveryImageName string = ''

resource resourceGroup 'Microsoft.Resources/resourceGroups@2021-04-01' = {
  name: '${name}-rg'
  location: location
}

var resourceToken = toLower(uniqueString(subscription().id, name, location))
var tags = {
  'azd-env-name': name
}

module resources './resources.bicep' = {
  name: 'resources-${resourceToken}'
  scope: resourceGroup
  params: {
    name: name
    location: location
    principalId: principalId
    resourceToken: resourceToken
    checkoutImageName: checkoutImageName
    baconImageName: baconImageName
	  eggsImageName: eggsImageName
	  toastImageName: toastImageName
	  deliveryImageName: deliveryImageName
    tags: tags
  }
}

output AZURE_KEY_VAULT_ENDPOINT string = resources.outputs.AZURE_KEY_VAULT_ENDPOINT
output SERVICEBUS_ENDPOINT string = resources.outputs.SERVICEBUS_ENDPONT
output APPINSIGHTS_INSTRUMENTATIONKEY string = resources.outputs.APPINSIGHTS_INSTRUMENTATIONKEY
output AZURE_CONTAINER_REGISTRY_ENDPOINT string = resources.outputs.AZURE_CONTAINER_REGISTRY_ENDPOINT
output AZURE_CONTAINER_REGISTRY_NAME string = resources.outputs.AZURE_CONTAINER_REGISTRY_NAME
output APP_CHECKOUT_BASE_URL string = resources.outputs.CHECKOUT_APP_URI
output APP_BACON_BASE_URL string = resources.outputs.BACON_APP_URI
output APP_EGGS_BASE_URL string = resources.outputs.EGGS_APP_URI
output APP_TOAST_BASE_URL string = resources.outputs.TOAST_APP_URI
output APP_DELIVERY_BASE_URL string = resources.outputs.DELIVERY_APP_URI
output APP_APPINSIGHTS_INSTRUMENTATIONKEY string = resources.outputs.APPINSIGHTS_INSTRUMENTATIONKEY
