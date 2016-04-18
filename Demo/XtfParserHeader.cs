using System;
using System.Collections.Generic;
using System.Text;

namespace Survey
{
    public class XtfParserHeader
    {

        private const int XTF_HEADER_SONAR = 0; // sidescan and subbottom
        private const int XTF_HEADER_NOTES = 1; // notes - text annotation
        private const int XTF_HEADER_BATHY = 2; // bathymetry (Seabat, Odom)
        private const int XTF_HEADER_ATTITUDE = 3; // TSS or MRU attitude (pitch, roll, heave, yaw)
        private const int XTF_HEADER_FORWARD = 4; // forward-look sonar (polar display)
        private const int XTF_HEADER_ELAC = 5; // Elac multibeam
        private const int XTF_HEADER_RAW_SERIAL = 6; // Raw data from serial port
        private const int XTF_HEADER_EMBED_HEAD = 7; // Embedded header classure
        private const int XTF_HEADER_HIDDEN_SONAR = 8; // hidden (non-displayable) ping
        private const int XTF_HEADER_SEAVIEW_ANGLES = 9; // Bathymetry (angles) for Seaview
        private const int XTF_HEADER_SEAVIEW_DEPTHS = 10; // Bathymetry from Seaview data (depths)
        private const int XTF_HEADER_HIGHSPEED_SENSOR = 11; // used by Klein (Cliff Chase) 0=roll, 1=yaw
        public const int XTF_HEADER_ECHOSTRENGTH = 12; // Elac EchoStrength (10 values)
        private const int XTF_HEADER_GEOREC = 13; // Used to store mosaic params
        private const int XTF_HEADER_K5000_BATHYMETRY = 14; // Bathymetry data from the Klein 5000
        private const int XTF_HEADER_HIGHSPEED_SENSOR2 = 15; // High speed sensor from Klein 5000

        private const int FMT_XTF = 123; // unique ID for all XTF files.
    }

// Channel information classure (contained in the file header).
// One-time information describing each channel.  64 bytes long.
// This is data pertaining to each channel that will not change
// during the course of a run.
///////////////////////////////////////////////////////////////////////////////
        public class CHANINFO
        {
            public byte TypeOfChannel; // PORT, STBD, SBOT or BATH
            public byte SubChannelNumber;
            public ushort CorrectionFlags; // 1=raw, 2=Corrected
            public ushort UniPolar; // 0=data is bipolar, 1=data is unipolar

            public ushort bytesPerSample; // 1 or 2
            public uint Reserved; // Previously this was SamplesPerChannel.  Isis now supports
            // the recording of every sample per ping, which means that
            // number of samples per channel can vary from ping to ping
            // if the range scale changes.  Because of this, the 
            // NumSamples value in the XTFPINGCHANHEADER strcture (below)
            // holds the number of samples to read for a given channel.
            // For standard analog systems, this Reserved value is still
            // filled in with 1024, 2048 or whatever the initial value is
            // for SamplesPerChannel.

            public  char[] ChannelName; // Text describing channel.  i.e., "Port 500"

            public float VoltScale; // How many volts is represented by max sample value.  Typically 5.0.
            public float Frequency; // Center transmit frequency
            public float HorizBeamAngle; // Typically 1 degree or so
            public float TiltAngle; // Typically 30 degrees
            public float BeamWidth; // 3dB beam width, Typically 50 degrees

            // Orientation of these offsets:
            // Positive Y is forward
            // Positive X is to starboard
            // Positive Z is down.  Just like depth.
            // Positive roll is lean to starboard
            // Positive pitch is nose up
            // Positive yaw is turn to right

            public float OffsetX; // These offsets are entered in the 
            public float OffsetY; // Multibeam setup dialog box.
            public float OffsetZ;

            public float OffsetYaw; // If the multibeam sensor is reverse
            // mounted (facing backwards), then
            // OffsetYaw will be around 180 degrees.
            public float OffsetPitch;
            public float OffsetRoll;

            public ushort BeamsPerArray; // For forward look only (i.e., Sonatech DDS)

            public byte SampleFormat;
            public char[] ReservedArea2;
            public CHANINFO()
            {
                ChannelName = new char[16];
                ReservedArea2 = new char[53];
            }
        };
   
// XTF File header.
// Total of 1024 bytes.
///////////////////////////////////////////////////////////////////////////////
        public class XTFFILEHEADER
        {
            public byte FileFormat; // 50 for Q-MIPS file format, 51 for Isis format
            public byte SystemType; // Type of system used to record this file.  202=Isis
            public char[] RecordingProgramName; // Example: "Isis"
            public char[] RecordingProgramVersion; // Example: "1.72"
            public char[] SonarName; // Name of server used to access sonar.  Example: "C31_SERV.EXE"
            public ushort SonarType; // K2000=5, DF1000=7, SEABAT=8
            public char[] NoteString; // Notes as entered in the Sonar Setup dialog box
            public char[] ThisFileName; // Name of this file. Example:"LINE12-B.XTF"

            public ushort NavUnits; // 0=METERS or 3=DEGREES

            public ushort NumberOfSonarChannels; // if > 60, header goes to 8K in size
            public ushort NumberOfBathymetryChannels;
            public ushort NumberOfForwardLookArrays;
            public ushort NumberOfEchoStrengthChannels;
            public byte NumberOfInterferometryChannels;
            public byte Reserved1;
            public ushort Reserved2;
            public float ReferencePointHeight;

            // nav system parameters
            ///////////////////////////
            public  byte[] ProjectionType; // Not currently used
            public  byte[] SpheriodType; // Not currently used
            public long NavigationLatency; // milliseconds, latency of nav system (usually GPS)
            // This value is entered on the
            // Serial port setup dialog box.  
            // When computing a position, Isis will
            // take the time of the navigation 
            // and subtract this value.

            public float OriginY; // Not currently used
            public float OriginX; // Not currently used

            // Orientation of these offsets:
            // Positive Y is forward
            // Positive X is to starboard
            // Positive Z is down.  Just like depth.
            // Positive roll is lean to starboard
            // Positive pitch is nose up
            // Positive yaw is turn to right

            public float NavOffsetY; // These offsets are entered in
            public float NavOffsetX; // the multibeam setup dialog box.
            public float NavOffsetZ;
            public float NavOffsetYaw;

            public float MRUOffsetY; // These offsets are entered in
            public float MRUOffsetX; // the multibeam setup dialog box
            public float MRUOffsetZ;

            public float MRUOffsetYaw;
            public float MRUOffsetPitch;
            public float MRUOffsetRoll;

            // note: even 128-byte boundary to here

            public List<CHANINFO> ChanInfo;// Each CHANINFO class is 128 bytes.
            // If more than 6 channels needed, header record
            // grows 1K in size for each additional 8 channels.
            public XTFFILEHEADER()
            {
                RecordingProgramName = new char[8];
                RecordingProgramVersion = new char[8];
                SonarName = new char[16];
                NoteString = new char[64];
                ThisFileName =new char[64];
                ProjectionType = new byte[12];
                SpheriodType = new byte[10];
                ChanInfo = new List<CHANINFO>();
                for (int i = 0; i < 6; i++)
                {
                    ChanInfo.Add(new CHANINFO());
                }
                
            }

            public byte[] pack()
            {
                byte[] dataBytes = new byte[1024];
                dataBytes[0] = FileFormat;
                dataBytes[1] = SystemType;
                Buffer.BlockCopy(RecordingProgramName, 0, dataBytes, 2, 8);
                Buffer.BlockCopy(RecordingProgramVersion,0,dataBytes, 10, 8);
                Buffer.BlockCopy(SonarName, 0, dataBytes, 18, 16);
                Buffer.BlockCopy(BitConverter.GetBytes(SonarType), 0, dataBytes, 34, 2);
                Buffer.BlockCopy(NoteString, 0, dataBytes, 36, 64);
                Buffer.BlockCopy(ThisFileName, 0, dataBytes,100, 64);
                Buffer.BlockCopy(BitConverter.GetBytes(NavUnits), 0, dataBytes, 164, 2);
                Buffer.BlockCopy(BitConverter.GetBytes(NumberOfSonarChannels), 0, dataBytes, 166, 2);
                Buffer.BlockCopy(BitConverter.GetBytes(NumberOfBathymetryChannels), 0, dataBytes, 168, 2);
                Buffer.BlockCopy(BitConverter.GetBytes(NumberOfForwardLookArrays), 0, dataBytes, 170, 2);
                Buffer.BlockCopy(BitConverter.GetBytes(NumberOfEchoStrengthChannels), 0, dataBytes, 172, 2);
                dataBytes[175] = NumberOfInterferometryChannels;
                Buffer.BlockCopy(BitConverter.GetBytes(NavigationLatency), 0, dataBytes, 204, 4);
                Buffer.BlockCopy(BitConverter.GetBytes(NavOffsetY), 0, dataBytes, 216, 4);
                Buffer.BlockCopy(BitConverter.GetBytes(NavOffsetX), 0, dataBytes, 220, 4);
                Buffer.BlockCopy(BitConverter.GetBytes(NavOffsetZ), 0, dataBytes, 224, 4);
                Buffer.BlockCopy(BitConverter.GetBytes(NavOffsetYaw), 0, dataBytes, 228, 4);
                Buffer.BlockCopy(BitConverter.GetBytes(MRUOffsetY), 0, dataBytes, 232, 4);
                Buffer.BlockCopy(BitConverter.GetBytes(MRUOffsetX), 0, dataBytes, 236, 4);
                Buffer.BlockCopy(BitConverter.GetBytes(MRUOffsetZ), 0, dataBytes, 240, 4);
                Buffer.BlockCopy(BitConverter.GetBytes(MRUOffsetYaw), 0, dataBytes, 244, 4);
                Buffer.BlockCopy(BitConverter.GetBytes(MRUOffsetPitch), 0, dataBytes, 248, 4);
                Buffer.BlockCopy(BitConverter.GetBytes(MRUOffsetRoll), 0, dataBytes, 252, 4);

                for (int i = 0; i < 6; i++)//应该不会大于6
                {
                    int offset = 256+i*128;
                    dataBytes[offset] = ChanInfo[i].TypeOfChannel;
                    dataBytes[offset+1] = ChanInfo[i].SubChannelNumber;
                    Buffer.BlockCopy(BitConverter.GetBytes(ChanInfo[i].CorrectionFlags), 0, dataBytes, offset+2, 2);
                    Buffer.BlockCopy(BitConverter.GetBytes(ChanInfo[i].UniPolar), 0, dataBytes, offset + 4, 2);
                    Buffer.BlockCopy(BitConverter.GetBytes(ChanInfo[i].bytesPerSample), 0, dataBytes, offset + 6, 2);

                    Buffer.BlockCopy(ChanInfo[i].ChannelName, 0, dataBytes, offset+12, 16);
                    Buffer.BlockCopy(BitConverter.GetBytes(ChanInfo[i].VoltScale), 0, dataBytes, offset + 28, 4);
                    Buffer.BlockCopy(BitConverter.GetBytes(ChanInfo[i].Frequency), 0, dataBytes, offset + 32, 4);
                    Buffer.BlockCopy(BitConverter.GetBytes(ChanInfo[i].HorizBeamAngle), 0, dataBytes, offset + 36, 4);
                    Buffer.BlockCopy(BitConverter.GetBytes(ChanInfo[i].TiltAngle), 0, dataBytes, offset + 40, 4);
                    Buffer.BlockCopy(BitConverter.GetBytes(ChanInfo[i].BeamWidth), 0, dataBytes, offset + 44, 4);
                    Buffer.BlockCopy(BitConverter.GetBytes(ChanInfo[i].OffsetX), 0, dataBytes, offset + 48, 4);
                    Buffer.BlockCopy(BitConverter.GetBytes(ChanInfo[i].OffsetY), 0, dataBytes, offset + 52, 4);
                    Buffer.BlockCopy(BitConverter.GetBytes(ChanInfo[i].OffsetZ), 0, dataBytes, offset + 56, 4);
                    Buffer.BlockCopy(BitConverter.GetBytes(ChanInfo[i].OffsetYaw), 0, dataBytes, offset + 60, 4);
                    Buffer.BlockCopy(BitConverter.GetBytes(ChanInfo[i].OffsetPitch), 0, dataBytes, offset + 64, 4);
                    Buffer.BlockCopy(BitConverter.GetBytes(ChanInfo[i].OffsetRoll), 0, dataBytes, offset + 68, 4);
                    Buffer.BlockCopy(BitConverter.GetBytes(ChanInfo[i].BeamsPerArray), 0, dataBytes, offset + 72, 2);
                    dataBytes[offset + 74] = ChanInfo[i].SampleFormat;
                }
                return dataBytes;
            }
        };


// The XTFATTITUDEDATA classure used to store information from a TSS or 
// MRU motion sensor device.  This is usually high-resolution data
// (updating 20 times per second or more) and is needed when processing
// multibeam bathymetric data.  When TSS or MRU is selected as a serial device,
// the data is received and decoded.  As the attitude information is decoded,
// the values are filled into the following classure and then saved to the 
// XTF file.
//
// Attitude data packet, 64 bytes in length.
///////////////////////////////////////////////////////////////////////////////
        public class XTFATTITUDEDATA
        {
            // 
            // Type of header
            //
            public ushort MagicNumber; // Always set to 0xFACE
            public byte HeaderType; // XTF_HEADER_ATTITUDE (3)
            public byte SubChannelNumber; // When HeaderType is Bathy, indicates which head
            public ushort NumChansToFollow; // If Sonar Ping, Number of channels to follow
            public  ushort[] Reserved1;

            public uint NumbytesThisRecord; // Total byte count for this ping including this ping header
            // Note: Isis records data packets in multiples of 64 bytes.
            // If the size of the data packet is not an exact multiple of
            // 64 bytes, zeros are padded at the end packet and this value
            // will be promoted to the next 64-byte granularity.  In all
            // cases, this value will be the EXACT size of this packet
            //
            public uint[] Reserved2;

            // will be followed by attitude data even to 64 bytes
            public float Pitch; // positive value is nose up
            public float Roll; // positive value is roll to starboard
            public float Heave; // positive value is sensor up
            // Note: The TSS sends heave positive up.  The MRU
            // sends heave positive down.  In order to make the 
            // data logging consistent, the sign of the MRU's 
            // heave is reversed before being stored in this field.

            public float Yaw; // positive value is turn right
            public uint TimeTag; // time ref. given in milliseconds

            public float Heading; // In degrees, as reported by MRU.  
            // TSS doesn't report heading, so when using a TSS 
            // this value will be the most recent ship gyro value 
            // as received from GPS or from any serial port using 
            // 'G' in the template.

            public  byte[] Reserved3;

            public XTFATTITUDEDATA()
            {
                Reserved1 = new ushort[2];
                Reserved2 = new uint[4];
                Reserved3 =new byte[10];
            }
        };


// Sonar or Bathy Ping header
// The data here can change from ping to ping but will pertain to all
// channels that are at the same time as this ping.  256 bytes in length.
///////////////////////////////////////////////////////////////////////////////
        public class XTFPINGHEADER
        {

            // 
            // Type of header
            //
            public ushort MagicNumber; // Set to 0xFACE
            public byte HeaderType; // Typically XTF_HEADER_SONAR (0), XTF_HEADER_BATHY (2),
            // XTF_HEADER_ATTITUDE
            public byte SubChannelNumber; // When HeaderType is Bathy, indicates which head
            // When sonar, which ping of a batch (Klein 5000: 0..4)

            public ushort NumChansToFollow; // If Sonar Ping, Number of channels to follow
            public  ushort[] Reserved1;

            public uint NumbytesThisRecord; // Total byte count for this ping including this ping header

            //
            // Date and time of the ping
            //
            public ushort Year; // Computer date when this record was saved
            public byte Month;
            public byte Day;
            public byte Hour; // Computer time when this record was saved
            public byte Minute;
            public byte Second;
            public byte HSeconds; // hundredths of seconds (0-99)
            public ushort JulianDay; // Number of days since January 1

            //
            // General information
            //
            public uint EventNumber; // [O] Last logged event number

            public uint PingNumber; // Counts consecutively from 0 and increments 
            //   for each update.  Note that the
            //   counters are different between sonar
            //   and bathymetery updates.

            public float SoundVelocity; // m/s, Round trip, defaults to 750. 
            //   Can be changed on Isis menu.  This
            //   value is never computed and can only be 
            //   changed manually by the user. Also see 
            //   ComputedSoundVelocity below.

            public float OceanTide; // [{t}] Ocean tide in meters.  Can be
            // changed by the user on the Configure 
            // menu in Isis.
            public uint Reserved2; // Reserved for future use

            //
            // Raw CTD information.  The Freq values are those sent up by the
            // SeaBird CTD.  The Falmouth Scientific CTD sends up computed data.
            public float ConductivityFreq; // [Q] Conductivity frequency in Hz
            public float TemperatureFreq; // [b] Temperature frequency in Hz
            public float PressureFreq; // [0] Pressure frequency in Hz
            public float PressureTemp; // [;] Pressure Temperature (Degrees C)

            // 
            // Computed CTD information.  When using a SeaBird CTD, these
            // values are computed from the raw Freq values (above).
            //
            public float Conductivity; // [{c}] Conductivity in S/m can be computed from [Q]
            public float WaterTemperature; // [{w}] Water temperature in C, can be computed from [b]
            public float Pressure; // [{p}] Water pressure in psia, can be computed from [0]
            public float ComputedSoundVelocity; // Meters per second, computed from
            // Conductivity, WaterTemperature and 
            // Pressure using the Chen Millero
            // formula (1977) formula (JASA,62,1129-1135).


            //
            // Sensors information
            //
            public float MagX; // [e] X-axis magnetometer data, mgauss
            public float MagY; // [w] Y-axis magnetometer data, mgauss
            public float MagZ; // [z] Z-axis magnetometer data, mgauss

            // Auxillary values can be used to store
            // and display any value at the user's
            // discretion.  The are not used in
            // any calculation in Isis, Target or Vista.

            public float AuxVal1; // [1] Auxillary value.  Displayed in the 
            public float AuxVal2; // [2] Auxillary value   "Sensors" window
            public float AuxVal3; // [3] Auxillary value   available by selecting
            public float AuxVal4; // [4] Auxillary value   Window->Text->Sensors.
            public float AuxVal5; // [5] Auxillary value
            public float AuxVal6; // [6] Auxillary value

            public float SpeedLog; // [s] Speed log sensor on towfish - knots. This isn't fish speed!
            public float Turbidity; // [|] turbidity sensor (0 to  volts) stored times 10000

            //
            // Ship Navigation information.  These values are stored only
            // and are not part of any equation or computation in Isis.
            //
            public float ShipSpeed; // [v] Speed of ship in knots.  Stored
            public float ShipGyro; // [G] Ship gyro in degrees
            public double ShipYcoordinate; // [y] Ship latitude or northing
            public double ShipXcoordinate; // [x] Ship longitude or easting

            public ushort ShipAltitude; // Decimeters (meters*10, stored only)
            public ushort ShipDepth; // Decimeters (meters*10, stored only)

            // 
            // Sensor Navigation information
            //
            public byte FixTimeHour; // [H] Hour of most recent nav update
            public byte FixTimeMinute; // [I] Minute of most recent nav update
            public byte FixTimeSecond; // [S] Second of most recent nav update
            // Note that the time of the nav is
            // adjusted by the NavLatency stored in 
            // the XTF file header.
            public byte FixTimeHSecond;
            public float SensorSpeed; // [V] Speed of the in knots.  Used for
            //   speed correction and position calculation.
            public float KP; // [{K}] Kilometers Pipe
            public double SensorYcoordinate; // [E] Sensor latitude or northing
            public double SensorXcoordinate; // [N] Sensor longitude or easting
            // Note: when NavUnits in the file header
            // is 0, values are in meters (northings
            // and eastings).  When NavUnits is 3,
            // values are in Lat/Long.  Also see
            // the Layback value, below.

            //
            // Tow Cable information
            //
            public ushort SonarStatus; // System status value, sonar dependant (displayed in Status window)
            public ushort RangeToFish; // [?] Slant range to fish * 10.  
            //    Not currently used.
            public ushort BearingToFish; // [>] Bearing to towfish from ship * 100.  
            //    Not currently used.
            public ushort CableOut; // [o] Amount of cable payed out in meters
            //    Not currently used in Isis.
            public float Layback; // [l] Distance over ground from ship to fish.
            //    When this value is non-zero, Isis
            //    assumes that SensorYcoordinate and 
            //    SensorXcoordinate need to be
            //    adjusted with the Layback.  The sensor 
            //    position is then computed using the 
            //    current sensor heading and this layback 
            //    value.  The result is displayed when a 
            //    position is computed in Isis. 

            public float CableTension; // [P] Cable tension from serial port. Stored only.

            //      
            // Sensor Attitude information
            //
            public float SensorDepth; // [0] Distance from sea surface to
            //   sensor.  The deeper the sensor goes, 
            //   the bigger (positive) this value becomes.

            public float SensorPrimaryAltitude;
            // [7] Distance from towfish to the sea
            //   floor.  This is the primary altitude as 
            //   tracked by the Isis bottom tracker or
            //   entered manually by the user. 
            //   Although not recommended, the user can 
            //   override the Isis bottom tracker by 
            //   sending the primary altitude over the 
            //   serial port.  The user should turn the 
            //   Isis bottom tracker Off when this is done.

            public float SensorAuxAltitude; // [a] Auxillary altitude.  This is an
            //   auxillary altitude as transmitted by an 
            //   altimeter and received over a serial port.
            //   The user can switch betwen the Primary and 
            //   Aux altitudes via the "options" button in 
            //   the Isis bottom track window.

            public float SensorPitch; // [8] Pitch in degrees (positive=nose up)
            public float SensorRoll; // [9] Roll in degrees (positive=roll to stbd)
            public float SensorHeading; // [h] Fish heading in degrees

            // These Pitch, Roll, Heading, Heave and Yaw values are those received 
            // closest in time to this sonar or bathymetry update.  If a TSS or MRU
            // is being used with a multibeam/bathymetry sensor, the user should 
            // use the higher-resolution attitude data found in the XTFATTITUDEDATA 
            // classures.


            //
            // additional attitude data
            //
            public float Heave; // Sensor heave at start of ping. 
            // Positive value means sensor moved up.
            public float Yaw; // Sensor yaw.  Positive means turn to right.
            public uint AttitudeTimeTag; // milliseconds - used to coordinate with millisecond 
            // time value in Attitude packet

            //
            // Misc.
            //
            public float DOT; // Distance Off Track

            public uint NavFixMilliseconds; //	millisecond clock value when nav received

            //
            // The Isis computer clock time when this ping was received.
            // May be different from ping time at start of this record if
            // the sonar time-stamped the data and the two systems aren't synced.
            // This time should be ignored in most cases.
            //
            public byte ComputerClockHour;
            public byte ComputerClockMinute;
            public byte ComputerClockSecond;
            public byte ComputerClockHsec;

            //
            // Additional Tow Cable and Fish information from Trackpoint
            //
            public short FishPositionDeltaX;
                // [{DX}] Stored as meters*3.0, supporting  10000.0m (usually from trackpoint)

            public short FishPositionDeltaY; // [{DY}] X,Y offsets can be used instead of logged layback.

            public byte FishPositionErrorCode;
                // Error code for FishPosition delta x,y (typically reported by Trackpoint)

            //
            // Pad to make an even 256 bytes
            //
            public  byte[] ReservedSpace2; // Currently unused

            public XTFPINGHEADER()
            {
                Reserved1= new ushort[2];
                ReservedSpace2 = new byte[11];
            }
        };



// Annotation record
// An annotation record is a line of text which can be saved to the
// file and is displayed in the "Notes" field on the Isis display.
// This text is displayed during playback.  Additionally, this text
// may be printed in realtime or in playback.  This can be activated
// in the Print Annotation dialog box.
///////////////////////////////////////////////////////////////////////////////
        public class XTFNOTESHEADER
        {

            public ushort MagicNumber; // Set to 0xFACE
            public byte HeaderType; // XTF_HEADER_NOTES (1)
            public byte SubChannelNumber;
            public ushort NumChansToFollow;
            public  ushort[] Reserved;
            public uint NumbytesThisRecord; // Total byte count for this update

            //
            // Date and time of the annotation
            //
            public ushort Year;
            public byte Month;
            public byte Day;
            public byte Hour;
            public byte Minute;
            public byte Second;
            public  byte[] Reservedbytes;

            public  char[] NotesText;

            public XTFNOTESHEADER()
            {
                Reserved = new ushort[2];
                Reservedbytes = new byte[35];
                NotesText = new char[200];
            }
        };


// RAW ASCII data received over serial port
// These packets are stored in the XTF file on a per-serial-port
// basis.  To store the raw ASCII data for a given serial port, add 
// the token "{SAVEALL}" to the serial port template.  Use of this
// option is not generally recommended, since Isis already parses the
// data for all usefull information.

///////////////////////////////////////////////////////////////////////////////
        public class XTFRAWSERIALHEADER
        {

            public ushort MagicNumber; // Set to 0xFACE
            public byte HeaderType; // will be XTF_HEADER_RAW_SERIAL (7)
            public byte SerialPort;
            public ushort[] Reserved1;
            public uint NumbytesThisRecord; // Total byte count for this update

            //
            // Date and time raw ASCII data was posted to disk
            //
            public ushort Year;
            public byte Month;
            public byte Day;
            public byte Hour;
            public byte Minute;
            public byte Second;
            public byte HSeconds; // hundredth of seconds (0-99)
            public ushort JulianDay; // days since Jan 1.

            public uint TimeTag; // millisecond timer value
            public ushort StringSize; // Number of valid chars in RawAsciiData string
            public  char[] RawAsciiData; // will be padded in 64-byte increments to make 
            // classure an even multiple of 64 bytes
            public XTFRAWSERIALHEADER()
            {
                Reserved1 = new ushort[3];
                RawAsciiData =new char[34];
            }
        };


// Ping Channel header 
// This is data that can be unique to each channel from ping to ping.
// Is is stored at the front of each channel of sonar data.
///////////////////////////////////////////////////////////////////////////////
        public class XTFPINGCHANHEADER
        {

            public ushort ChannelNumber; // Typically, 
            // 0=port (low frequency)
            // 1=stbd (low frequency)
            // 2=port (high frequency)
            // 3=stbd (high frequency)

            public ushort DownsampleMethod; // 2=MAX, 4=RMS
            public float SlantRange; // Slant range of the data in meters
            public float GroundRange; // Ground range of the data in meters
            //   (SlantRange^2 - Altitude^2)
            public float TimeDelay; // Amount of time (in seconds) to the start of recorded data
            //   almost always 0.0
            public float TimeDuration; // Amount of time (in seconds) recorded
            public float SecondsPerPing; // Amount of time (in seconds) from ping to ping

            public ushort ProcessingFlags; // 4=TVG, 8=BAC&GAC, 16=Filter, etc...
            //   almost always 0
            public ushort Frequency; // Center transmit frequency for this channel.
            //   when non-zero, replaces value found in file
            //   header CHANINFO class ChanInfo->SamplesPerChannel.
            //   This allows samples per channel to change on the fly.

            public ushort InitialGainCode; // Settings as transmitted by sonar
            public ushort GainCode;
            public ushort BandWidth;

            //
            // Contact information - updated when contacts are saved through Target.exe
            //
            public uint ContactNumber;
            public ushort ContactClassification;
            public byte ContactSubNumber;
            public byte ContactType;


            public uint NumSamples; // Number of samples that will follow this classure.  The
            // number of bytes will be this value multipied by the
            // number of bytes per sample (given in the file header)

            public ushort MillivoltScale; // Obsolete.
            public float ContactTimeOffTrack; // Time off track to this contact (stored in milliseconds)
            public byte ContactCloseNumber;
            public byte Reserved2;

            public float FixedVSOP; //  along-track size of each ping, stored in cm.
            //  on multibeam system with zero beam spread, this value
            //  needs to be filled in to prevent Isis from calculating
            //  along-track ground coverage based on beam spread and 
            //  speed over ground.
            public ushort Weight;

            public  byte[] ReservedSpace; // reserved for future expansion

            public XTFPINGCHANHEADER()
            {
                ReservedSpace = new byte[4];
            }
        };

}
