//============================================================-
//	CDIOUSBCS.CS
//	Class file for CONTEC Digital I/O device
//												CONTEC.Co.,Ltd.
//============================================================-

using	System;
using	System.Runtime.InteropServices;

public enum CdioUsbConst
{
//-------------------------------------------------
//	Type definition
//-------------------------------------------------
	DEVICE_TYPE_ISA		=	0,	//	ISA or C bus
	DEVICE_TYPE_PC		=	1,	//	PCI bus
	DEVICE_TYPE_PCMCIA	=	2,	//	PCMCIA
	DEVICE_TYPE_USB		=	3,	//	USB
	DEVICE_TYPE_FIT		=	4,	//	FIT

//-------------------------------------------------
//	Parameters
//-------------------------------------------------
//	I/O(for Sample)
	DIO_MAX_ACCS_PORTS	=	256,
//	DioNotifyInt:Logic
	DIO_INT_RISE		=	1,
	DIO_INT_FALL		=	2,
//	DioNotifyTrg:TrgKind
	DIO_TRG_RISE		=	1,
	DIO_TRG_FALL		=	2,
//	Message
	DIOM_INTERRUPT		=	0x1300,
	DIOM_TRIGGER		=	0x1340,
//	Device	Information
	IDIO_DEVICE_TYPE		=	0,	//	device type.					Param1:short
	IDIO_NUMBER_OF_8255		=	1,	//	Number of 8255 chip.			Param1:int
	IDIO_IS_8255_BOARD		=	2,	//	Is 8255	board?					Param1:BOOL(True/False)
	IDIO_NUMBER_OF_DI_BIT	=	3,	//	Number of digital input bit.	Param1:int
	IDIO_NUMBER_OF_DO_BIT	=	4,	//	Number of digital outout bit.	Param1:int
	IDIO_NUMBER_OF_DI_PORT	=	5,	//	Number of digital input	port.	Param1:int
	IDIO_NUMBER_OF_DO_PORT	=	6,	//	Number of digital output port.	Param1:int
	IDIO_IS_POSITIVE_LOGIC	=	7,	//	Is positive logic?				Param1:BOOL(True/False)
	IDIO_IS_ECHO_BACK		=	8,	//	Can echo back output port?		Param1:BOOL(True/False)

//-------------------------------------------------
//	Error	codes
//-------------------------------------------------
//	Initialize	Error
//	Common
	DIO_ERR_SUCCESS			=	0,		//	：normal completed
	DIO_ERR_INI_RESOURCE	=	1,		//	：invalid resource reference specified
	DIO_ERR_INI_INTERRUPT	=	2,		//	：invalid interrupt routine registered
	DIO_ERR_INI_MEMORY		=	3,		//	：invalid memory allocationed
	DIO_ERR_INI_REGISTRY	=	4,		//	：invalid registry accesse

//	DLL	Error
//	Common
	DIO_ERR_DLL_DEVICE_NAME			=	10000,	//	：invalid device name specified.
	DIO_ERR_DLL_INVALID_ID			=	10001,	//	：invalid ID specified.
	DIO_ERR_DLL_CALL_DRIVER			=	10002,	//	：not call the driver.(Invalid device I/O controller)
	DIO_ERR_DLL_CREATE_FILE			=	10003,	//	：not create the file.(Invalid CreateFile)
	DIO_ERR_DLL_CLOSE_FILE			=	10004,	//	：not close the file.(Invalid CloseFile)
	DIO_ERR_DLL_CREATE_THREAD		=	10005,	//	：not create the thread.(Invalid CreateThread)
	DIO_ERR_INFO_INVALID_DEVICE		=	10050,	//	：invalid device infomation specified .Please check the spell.
	DIO_ERR_INFO_NOT_FIND_DEVICE	=	10051,	//	：not find the available device
	DIO_ERR_INFO_INVALID_INFOTYPE	=	10052,	//	：specified device infomation type beyond the limit

//	DIO
	DIO_ERR_DLL_BUFF_ADDRESS		=	10100,	//	：invalid data buffer address
	DIO_ERR_DLL_HWND				=	10200,	//	：window handle beyond the limit
	DIO_ERR_DLL_TRG_KIND			=	10300,	//	：trigger kind beyond the limit

//	SYS	Error
//	Common
	DIO_ERR_SYS_MEMORY				=	20000,	//	：not secure memory
	DIO_ERR_SYS_NOT_SUPPORTED		=	20001,	//	：this board couldn't use this function
	DIO_ERR_SYS_BOARD_EXECUTING		=	20002,	//	：board is behaving, not execute
	DIO_ERR_SYS_USING_OTHER_PROCESS	=	20003,	//	：other process is using the device, not execute

	STATUS_SYS_USB_CRC						=	20020,	//	the last data packet received from end point exist CRC error
	STATUS_SYS_USB_BTSTUFF					=	20021,	//	the last data packet received from end point exist bit stuffing offense error
	STATUS_SYS_USB_DATA_TOGGLE_MISMATCH		=	20022,	//	the last data packet received from end point exist toggle packet mismatch error
	STATUS_SYS_USB_STALL_PID				=	20023,	//	end point return STALL packet identifier
	STATUS_SYS_USB_DEV_NOT_RESPONDING		=	20024,	//	device don't respond to token(IN), don't support handshake
	STATUS_SYS_USB_PID_CHECK_FAILURE		=	20025,	
	STATUS_SYS_USB_UNEXPECTED_PID			=	20026,	//	invalid packet identifier received
	STATUS_SYS_USB_DATA_OVERRUN				=	20027,	//	end point return data quantity overrun
	STATUS_SYS_USB_DATA_UNDERRUN			=	20028,	//	end point return data quantity underrun
	STATUS_SYS_USB_BUFFER_OVERRUN			=	20029,	//	IN transmit specified buffer overrun
	STATUS_SYS_USB_BUFFER_UNDERRUN			=	20030,	//	OUT transmit specified buffer underrun
	STATUS_SYS_USB_ENDPOINT_HALTED			=	20031,	//	end point status is STALL, not transmit
	STATUS_SYS_USB_NOT_FOUND_DEVINFO		=	20032,	//	not found device infomation
	STATUS_SYS_USB_ACCESS_DENIED			=	20033,	//	Access denied
	STATUS_SYS_USB_INVALID_HANDLE			=	20034,	//	Invalid handle

//	DIO
	DIO_ERR_SYS_PORT_NO						=	20100,	//	：board No. beyond the limit
	DIO_ERR_SYS_PORT_NUM					=	20101,	//	：board number beyond the limit
	DIO_ERR_SYS_BIT_NO						=	20102,	//	：bit No. beyond the limit
	DIO_ERR_SYS_BIT_NUM						=	20103,	//	：bit number beyond the limit
	DIO_ERR_SYS_BIT_DATA					=	20104,	//	：bit data beyond the limit of 0 to 1
	DIO_ERR_SYS_INT_BIT						=	20200,	//	：interrupt bit beyond the limit
	DIO_ERR_SYS_INT_LOGIC					=	20201,	//	：interrupt logic beyond the limit
	DIO_ERR_SYS_TIM							=	20300,	//	：timer value beyond the limit
	DIO_ERR_SYS_FILTER						=	20400,	//	：filter number beyond the limit
	DIO_ERR_SYS_IODIRECTION					=	20500	//	：Direction value is out of range
}

namespace CdioUsbCs
{
	public class CdioUsb
	{
		// Definition of common functions
		[DllImport("cdio.dll")] static extern int DioInit(string DeviceName, ref short Id);
		[DllImport("cdio.dll")] static extern int DioExit(short Id);
		[DllImport("cdio.dll")] static extern int DioResetDevice(short Id);
		[DllImport("cdio.dll")] static extern int DioGetErrorString(int ErrorCode, System.Text.StringBuilder ErrorString);

		// Digital filter functions
		[DllImport("cdio.dll")] static extern int DioSetDigitalFilter(short Id, short FilterValue);
		[DllImport("cdio.dll")] static extern int DioGetDigitalFilter(short Id, ref short FilterValue);
		
		// I/O Direction functions
		[DllImport("cdio.dll")] static extern int DioSetIoDirection(short Id, uint dwDir);
		[DllImport("cdio.dll")] static extern int DioGetIoDirection(short Id, ref uint dwDir);
		[DllImport("cdio.dll")] static extern int DioSetIoDirectionEx(short Id, uint dwDir);
		[DllImport("cdio.dll")] static extern int DioGetIoDirectionEx(short Id, ref uint dwDir);
		
		// Simple I/O functions
		[DllImport("cdio.dll")] static extern int DioInpByte(short Id, short PortNo, ref byte Data);
		[DllImport("cdio.dll")] static extern int DioInpBit(short Id, short BitNo, ref byte Data);
		[DllImport("cdio.dll")] static extern int DioOutByte(short Id, short PortNo, byte Data);
		[DllImport("cdio.dll")] static extern int DioOutBit(short Id, short BitNo, byte Data);
		[DllImport("cdio.dll")] static extern int DioEchoBackByte(short Id, short PortNo, ref byte Data);
		[DllImport("cdio.dll")] static extern int DioEchoBackBit(short Id, short BitNo, ref byte Data);
		
		// Multiple I/O functions
		[DllImport("cdio.dll")] static extern int DioInpMultiByte(short Id, short[] PortNo, short PortNum, byte[] Data);
		[DllImport("cdio.dll")] static extern int DioInpMultiBit(short Id, short[] BitNo, short BitNum, byte[] Data);
		[DllImport("cdio.dll")] static extern int DioOutMultiByte(short Id, short[] PortNo, short PortNum, byte[] Data);
		[DllImport("cdio.dll")] static extern int DioOutMultiBit(short Id, short[] BitNo, short BitNum, byte[] Data);
		[DllImport("cdio.dll")] static extern int DioEchoBackMultiByte(short Id, short[] PortNo, short PortNum, byte[] Data);
		[DllImport("cdio.dll")] static extern int DioEchoBackMultiBit(short Id, short[] BitNo, short BitNum, byte[] Data);
		
		// Interrupt functions
		[DllImport("cdio.dll")] static extern int DioNotifyInt(short Id, short IntBit, short Logic, int hWnd);
		[DllImport("cdio.dll")] static extern int DioStopNotifyInt(short Id, short IntBit);
		
		// Trigger functions
		[DllImport("cdio.dll")] static extern int DioNotifyTrg(short Id, short TrgBit, short TrgKind, int Tim, int hWnd);
		[DllImport("cdio.dll")] static extern int DioStopNotifyTrg(short Id, short TrgBit);
		
		// Information functions
		[DllImport("cdio.dll")] static extern int DioGetDeviceInfo(string Device, short InfoType, ref int Param1, ref int Param2, ref int Param3);
		[DllImport("cdio.dll")] static extern int DioQueryDeviceName(short Index, System.Text.StringBuilder DeviceName, System.Text.StringBuilder Device);
		[DllImport("cdio.dll")] static extern int DioGetDeviceType(string Device, ref short DeviceType);
		[DllImport("cdio.dll")] static extern int DioGetMaxPorts(short Id, ref short InPortNum, ref short OutPortNum);

		// Constructor
		public CdioUsb()
		{
		}

		// Description of common functions
		public int Init(string DeviceName, out short Id)
		{
			Id = 0;
			int ret	= DioInit(DeviceName, ref Id);
			return	ret;
		}

		public int Exit(short Id)
		{
			int ret = DioExit(Id);
			return ret;
		}

		public int ResetDevice(short Id)
		{
			int ret = DioResetDevice(Id);
			return ret;
		}

		public int GetErrorString(int ErrorCode, out string ErrorString)
		{
			ErrorString = new String('0', 1);
			System.Text.StringBuilder errorstring = new System.Text.StringBuilder(256);
			int ret = DioGetErrorString(ErrorCode, errorstring);
			if(ret == 0)
			{
				ErrorString = errorstring.ToString();
			}
			return ret;
		}

		// Digital filter functions
		public int SetDigitalFilter(short Id, short FilterValue)
		{
			int ret = DioSetDigitalFilter(Id, FilterValue);
			return ret;
		}

		public int GetDigitalFilter(short Id, out short FilterValue)
		{
			FilterValue = 0;
			int ret = DioGetDigitalFilter(Id, ref FilterValue);
			return ret;
		}

		// I/O Direction functions
		public int SetIoDirection(short Id, uint dwDir)
		{
			int ret = DioSetIoDirectionEx(Id, dwDir);
			return ret;
		}

		public int GetIoDirection(short Id, out uint dwDir)
		{
			dwDir = 0;
			int ret = DioGetIoDirectionEx(Id, ref dwDir);
			return ret;
		}
		
		public int SetIoDirectionEx(short Id, uint dwDir)
		{
			int ret = DioSetIoDirectionEx(Id, dwDir);
			return ret;
		}

		public int GetIoDirectionEx(short Id, out uint dwDir)
		{
			dwDir = 0;
			int ret = DioGetIoDirectionEx(Id, ref dwDir);
			return ret;
		}

		// Simple I/O functions
		public int InpByte(short Id, short PortNo, out byte Data)
		{
			Data = 0;
			int ret = DioInpByte(Id, PortNo, ref Data);
			return ret;
		}

		public int InpBit(short Id, short BitNo, out byte Data)
		{
			Data = 0;
			int ret = DioInpBit(Id, BitNo, ref Data);
			return ret;
		}

		public int OutByte(short Id, short PortNo, byte Data)
		{
			int ret = DioOutByte(Id, PortNo, Data);
			return ret;
		}

		public int OutBit(short Id, short BitNo, byte Data)
		{
			int ret = DioOutBit(Id, BitNo, Data);
			return ret;
		}

		public int EchoBackByte(short Id, short PortNo, out byte Data)
		{
			Data = 0;
			int ret = DioEchoBackByte(Id, PortNo, ref Data);
			return ret;
		}

		public int EchoBackBit(short Id, short BitNo, out byte Data)
		{
			Data = 0;
			int ret = DioEchoBackBit(Id, BitNo, ref Data);
			return ret;
		}

		// Multiple I/O functions
		public int InpMultiByte(short Id, short[] PortNo, short PortNum, byte[] Data)
		{
			int ret = DioInpMultiByte(Id, PortNo, PortNum, Data);
			return ret;
		}

		public int InpMultiBit(short Id, short[] BitNo, short BitNum, byte[] Data)
		{
			int ret = DioInpMultiBit(Id, BitNo, BitNum, Data);
			return ret;
		}

		public int OutMultiByte(short Id, short[] PortNo, short PortNum, byte[] Data)
		{
			int ret = DioOutMultiByte(Id, PortNo, PortNum, Data);
			return ret;
		}

		public int OutMultiBit(short Id, short[] BitNo, short BitNum, byte[] Data)
		{
			int ret = DioOutMultiBit(Id, BitNo, BitNum, Data);
			return ret;
		}

		public int EchoBackMultiByte(short Id, short[] PortNo, short PortNum, byte[] Data)
		{
			int ret = DioEchoBackMultiByte(Id, PortNo, PortNum, Data);
			return ret;
		}

		public int EchoBackMultiBit(short Id, short[] BitNo, short BitNum, byte[] Data)
		{
			int ret = DioEchoBackMultiBit(Id, BitNo, BitNum, Data);
			return ret;
		}

		// Interrupt functions
		public int NotifyInt(short Id, short IntBit, short Logic, int hWnd)
		{
			int ret = DioNotifyInt(Id, IntBit, Logic, hWnd);
			return ret;
		}

		public int StopNotifyInt(short Id, short IntBit)
		{
			int ret = DioStopNotifyInt(Id, IntBit);
			return ret;
		}

		// Trigger functions
		public int NotifyTrg(short Id, short TrgBit, short TrgKind, int Tim, int hWnd)
		{
			int ret = DioNotifyTrg(Id, TrgBit, TrgKind, Tim, hWnd);
			return ret;
		}

		public int StopNotifyTrg(short Id, short TrgBit)
		{
			int ret = DioStopNotifyTrg(Id, TrgBit);
			return ret;
		}

		// Information functions
		public int GetDeviceInfo(string Device, short InfoType, out int Param1, out int Param2, out int Param3)
		{
			Param1 = 0;
			Param2 = 0;
			Param3 = 0;
			int ret = DioGetDeviceInfo(Device, InfoType, ref Param1, ref Param2, ref Param3);
			return ret;
		}

		public int QueryDeviceName(short Index, out string DeviceName, out string Device)
		{
			DeviceName = new String('0', 1);
			Device = new String('0', 1);
			System.Text.StringBuilder devicename = new System.Text.StringBuilder(256);
			System.Text.StringBuilder device = new System.Text.StringBuilder(256);
			int ret = DioQueryDeviceName(Index, devicename, device);
			if(ret == 0)
			{
				DeviceName = devicename.ToString();
				Device = device.ToString();
			}
			return ret;
		}

		public int GetDeviceType(string Device, out short DeviceType)
		{
			DeviceType = 0;
			int ret = DioGetDeviceType(Device, ref DeviceType);
			return ret;
		}

		public int GetMaxPorts(short Id, out short InPortNum, out short OutPortNum)
		{
			InPortNum = 0;
			OutPortNum = 0;
			int ret = DioGetMaxPorts(Id, ref InPortNum, ref OutPortNum);
			return ret;
		}
	}
}
