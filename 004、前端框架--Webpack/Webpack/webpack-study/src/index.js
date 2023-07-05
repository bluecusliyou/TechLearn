// webpack打包的入口
import { addFn } from './add/add'
import { getArrSum } from './tool/tool'

console.log(addFn(5, 2));
console.log(getArrSum([5, 6, 9, 10]));