#IF_HEAD#
import {numberBuffer, booleanBuffer, stringBuffer} from './xbuffer'
import * as proto from './proto_class'
#END_HEAD#

export class #CLASS_NAME#Buffer
{
	public static deserialize(data:DataView, offset:number) : [proto.#CLASS_NAME#, number]
	{
		let value = new proto.#CLASS_NAME#();
#DESERIALIZE_PROCESS#
		// #VAR_NAME#
#IF_SINGLE#
		[value.#VAR_NAME#, offset] = #VAR_TYPE#Buffer.deserialize(data, offset);
#END_SINGLE#
#IF_ARRAY#
		let _#VAR_NAME#_length:number;
		[_#VAR_NAME#_length, offset] = numberBuffer.deserialize(data, offset);
		for (let i = 0; i < _#VAR_NAME#_length; i++)
		{
			[value.#VAR_NAME#[i], offset] = #VAR_TYPE#Buffer.deserialize(data, offset);
		}
#END_ARRAY#
#DESERIALIZE_PROCESS#

		return [value, offset];
	}

	public static serialize(value:proto.#CLASS_NAME#, data:DataView, offset:number) : number
	{
#SERIALIZE_PROCESS#
		// #VAR_NAME#
#IF_SINGLE#
		offset = #VAR_TYPE#Buffer.serialize(value.#VAR_NAME#, data, offset);
#END_SINGLE#
#IF_ARRAY#
		offset = numberBuffer.serialize(value.#VAR_NAME#.length, data, offset);
		for (let i = 0; i < value.#VAR_NAME#.length; i++)
		{
			offset = #VAR_TYPE#Buffer.serialize(value.#VAR_NAME#[i], data, offset);
		}
#END_ARRAY#
#SERIALIZE_PROCESS#

		return offset;
	}
}