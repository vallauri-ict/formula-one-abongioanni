ALTER TABLE [dbo].[Driver]  WITH CHECK ADD  CONSTRAINT [FK_Drivers_Countries] FOREIGN KEY([countryCode])
REFERENCES [dbo].[Country] ([countryCode])
ON UPDATE CASCADE;

ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Countries] FOREIGN KEY([countryCode])
REFERENCES [dbo].[Country] ([countryCode])
ON UPDATE CASCADE;

ALTER TABLE [dbo].[Team]  WITH CHECK ADD  CONSTRAINT [FK_Teams_Drivers] FOREIGN KEY([id])
REFERENCES [dbo].[Driver] ([TeamId])
ON UPDATE CASCADE;

ALTER TABLE [dbo].[Gp]  WITH CHECK ADD  CONSTRAINT [FK_Gp_Circuits] FOREIGN KEY([circuitID])
REFERENCES [dbo].[Circuit] ([circuitID])
ON UPDATE CASCADE;

ALTER TABLE [dbo].[Circuit]  WITH CHECK ADD  CONSTRAINT [FK_Circuits_Countries] FOREIGN KEY([countryCode])
REFERENCES [dbo].[Country] ([countryCode])
ON UPDATE CASCADE;

